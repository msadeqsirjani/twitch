﻿using Gridify.Meta;
using System.Collections.Generic;
using System.Linq;

namespace Gridify.Schema;

public class FieldResponse
{

    public FieldResponse()
    {
        IsVisible = true;
        IsVisibleDefault = true;
        IsSelectable = true;
    }

    public string Name { get; set; }
    public string Title { get; set; }
    public bool IsKey { get; set; }
    public bool IsVisible { get; set; }
    public bool IsVisibleDefault { get; set; }
    public bool IsEditable { get; set; }
    public bool IsSelectable { get; set; }
    public bool IsDetail { get; set; }
    public bool IsClickable { get; set; }
    public int Sequence { get; set; }
    public string DataType { get; set; }
    public List<FilterResponse> Filters { get; set; } = new();
    public List<OrderResponse> Orders { get; set; } = new();

    public FieldResponse FillFieldResponse(List<IMeta> metas)
    {
        if (metas == null)
            return this;

        metas.ForEach(meta =>
        {
            switch (meta.GetType().Name)
            {
                case nameof(MetaName):
                    Name = ((MetaName)meta).Name;
                    break;
                case nameof(MetaTitle):
                    Title = ((MetaTitle)meta).Title;
                    break;
                case nameof(MetaKey):
                    IsKey = true;
                    break;
                case nameof(MetaVisible):
                    IsVisible = ((MetaVisible)meta).IsVisible;
                    if (!IsVisible)
                        IsVisibleDefault = false;
                    break;
                case nameof(MetaVisibleDefault):
                    IsVisibleDefault = ((MetaVisibleDefault)meta).IsVisibleDefault;
                    break;
                case nameof(MetaSelectable):
                    IsSelectable = ((MetaSelectable)meta).IsSelectable;
                    break;
                case nameof(MetaEditable):
                    IsEditable = ((MetaEditable)meta).IsEditable;
                    break;
                case nameof(MetaDetail):
                    IsDetail = ((MetaDetail)meta).IsDetail;
                    break;
                case nameof(MetaSequence):
                    Sequence = ((MetaSequence)meta).Sequence;
                    break;
                case nameof(MetaDataType):
                    DataType = ((MetaDataType)meta).DataType;
                    break;
                case nameof(MetaClickable):
                    IsClickable = ((MetaClickable)meta).IsClickable;
                    break;
                case nameof(MetaOrder):
                    {
                        var metaOrder = (MetaOrder)meta;
                        if (!Orders.Any(x => x.Direction == metaOrder.Direction && x.OrderBy == metaOrder.OrderBy))
                        {
                            Orders.Add(new OrderResponse
                            {
                                OrderBy = metaOrder.OrderBy,
                                Direction = metaOrder.Direction
                            });
                        }

                        break;
                    }
                case nameof(MetaFilter):
                    {
                        var filter = new FilterResponse
                        {
                            DataType = ((MetaFilter)meta).DataType,
                            Fullname = ((MetaFilter)meta).Fullname,
                            Key = ((MetaFilter)meta).Key,
                            Assembly = ((MetaFilter)meta).Assembly,
                            Operator = ((MetaFilter)meta).Operator,
                        };

                        if (!Filters.Any(x =>
                                x.Key == filter.Key && x.Operator == filter.Operator && x.DataType == filter.DataType))
                        {
                            Filters.Add(filter);
                        }

                        break;
                    }
            }
        });

        return this;
    }
}