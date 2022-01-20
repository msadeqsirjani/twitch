using System.Collections.Generic;

namespace Gridify.Filter;

public class FilterList
{
    public FilterLogic Logic { get; set; }

    public List<Filter> Filters { get; set; }
}