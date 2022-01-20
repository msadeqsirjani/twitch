﻿using DynamicExpresso;
using Gridify.Filter;
using Gridify.Result;
using Gridify.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Gridify;

public static class Extensions
{
    private static readonly Dictionary<DataType, IFilterDataTypeStrategy> DataTypeStrategies = new();

    static Extensions()
    {
        DataTypeStrategies.Add(DataType.Int, new IntDataTypeStrategy());
        DataTypeStrategies.Add(DataType.Float, new FloatDataTypeStrategy());
        DataTypeStrategies.Add(DataType.Double, new DoubleDataTypeStrategy());
        DataTypeStrategies.Add(DataType.Long, new LongDataTypeStrategy());
        DataTypeStrategies.Add(DataType.Decimal, new DecimalDataTypeStrategy());
        DataTypeStrategies.Add(DataType.String, new StringDataTypeStrategy());
        DataTypeStrategies.Add(DataType.Char, new CharDataTypeStrategy());
        DataTypeStrategies.Add(DataType.DateTime, new DateTimeDataTypeStrategy());
        DataTypeStrategies.Add(DataType.Boolean, new BooleanDataTypeStrategy());
        DataTypeStrategies.Add(DataType.Enum, new EnumDataTypeStrategy());
        DataTypeStrategies.Add(DataType.Guid, new GuidTypeStrategy());
    }

    public static ServiceResult Gridify<T>(this IQueryable<T> queryable, GridRequest request) where T : new()
    {
        // Filter
        queryable = queryable.ApplyFiltering(request);

        // Count
        var count = queryable.Count();

        // Orders
        queryable = queryable.ApplyOrdering(request);

        // Paging
        queryable = queryable.ApplyPaging(request);

        return new ServiceResult(queryable, count);
    }

    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> queryable, GridRequest request)
    {
        if (request?.Pagination == null)
            return queryable;

        var pagination = request.Pagination;

        if (pagination.PageNumber > 0 && pagination.PageSize > 0)
            queryable = queryable.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize);

        return queryable;
    }

    public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> queryable, GridRequest request)
    {
        if (request?.Orders == null || !request.Orders.Any())
            return queryable;

        for (var i = 0; i < request.Orders.Count(); i++)
        {
            var orderList = request.Orders.ToArray()[i];

            if (!string.IsNullOrEmpty(orderList.OrderBy))
            {
                queryable = queryable.OrderBy(orderList.OrderBy + " " + orderList.Direction);
            }
        }

        return queryable;
    }

    public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> queryable, GridRequest request)
    {
        if (request?.Filters == null || !request.Filters.Any())
            return queryable;

        var whereExpression = string.Empty;
        var enumTypes = new List<KeyValuePair<string, string>>();

        for (var i = 0; i < request.Filters.Count(); i++)
        {
            var filterList = request.Filters.ToArray()[i];

            var (generatedWhereExpression, generatedEnumTypes) = GenerateDynamicWhereExpression(filterList);
            whereExpression += generatedWhereExpression;
            enumTypes.AddRange(generatedEnumTypes);

            if (i < request.Filters.Count() - 1)
            {
                whereExpression += ConvertLogicSyntax(FilterLogic.Or);
            }
        }

        var interpreter = new Interpreter().EnableAssignment(AssignmentOperators.None);
        foreach (var (key, value) in enumTypes)
        {
            var type = Type.GetType($"{key}, {value}");
            interpreter.Reference(type);
        }

        var expression = interpreter.ParseAsExpression<Func<T, bool>>(whereExpression, typeof(T).Name);
        queryable = queryable.Where(expression);

        return queryable;
    }

    #region [ Helpers ]

    private static (string, List<KeyValuePair<string, string>>) GenerateDynamicWhereExpression(FilterList filterList)
    {
        var dynamicExpressBuilder = new StringBuilder();
        var kvp = new List<KeyValuePair<string, string>>();

        for (var i = 0; i < filterList.Filters.Count(); i++)
        {
            var filter = filterList.Filters.ToArray()[i];

            if (filter.DataType == DataType.Enum)
            {
                kvp.Add(new KeyValuePair<string, string>(filter.Fullname, filter.Assembly));
            }

            dynamicExpressBuilder.Append(ConvertFilterToText(filter));
            if (i < filterList.Filters.Count() - 1)
            {
                dynamicExpressBuilder.Append(ConvertLogicSyntax(filterList.Logic));
            }
        }

        return ("(" + dynamicExpressBuilder + ")", kvp);
    }

    private static string ConvertLogicSyntax(FilterLogic filterListLogic)
    {
        return filterListLogic switch
        {
            FilterLogic.And => " && ",
            FilterLogic.Or => " || ",
            _ => throw new ArgumentOutOfRangeException(nameof(filterListLogic), filterListLogic, null)
        };
    }

    public static string ConvertFilterToText(Filter.Filter filter)
    {
        return DataTypeStrategies[filter.DataType].ConvertFilterToText(filter);
    }

    #endregion
}