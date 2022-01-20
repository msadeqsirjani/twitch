﻿using Gridify.Meta;
using Gridify.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Gridify;

public abstract class GridResponse<TSource> : IGridResponse where TSource : new()
{
    private readonly List<KeyValuePair<string, IMeta>> _metadata = new();

    public void Add(string key, IMeta meta)
    {
        var keyValuePair = new KeyValuePair<string, IMeta>(key, meta);
        _metadata.Add(keyValuePair);
    }

    [JsonIgnore]
    public SchemaResponse Schema
    {
        get
        {
            if (!_metadata.Any())
                InitSchema();
            return new SchemaResponse(_metadata);
        }
    }

    public MetaBuilder<TSource, TProperty> Meta<TProperty>(Expression<Func<TSource, TProperty>> expression)
    {
        var builder = new MetaBuilder<TSource, TProperty>(PropertyHelper<TSource>.GetProperty(expression), this);

        builder.AddMeta(builder.PropertyName, new MetaName { Name = builder.PropertyName });
        builder.AddMeta(builder.PropertyName, new MetaTitle { Title = builder.PropertyName });
        builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = builder.GetDataType() });

        return builder;
    }

    public abstract void InitSchema();
}