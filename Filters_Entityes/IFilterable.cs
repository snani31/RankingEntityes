using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Filters
{
    public interface IFilterable 
    {
        public IEnumerable<Filter> MatchFilters { get; set; }
    }
}
