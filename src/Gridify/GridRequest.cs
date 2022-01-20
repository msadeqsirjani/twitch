using Gridify.Filter;
using Gridify.Page;
using System.Collections.Generic;

namespace Gridify;

public class GridRequest
{
    public List<FilterList> Filters { get; set; }

    public List<Order.Order> Orders { get; set; }

    public Pagination Pagination { get; set; }

    public bool Schema { get; set; }
}

public class GridRequest<TSource> : GridRequest
{
    public TSource Parameter { get; set; }
}