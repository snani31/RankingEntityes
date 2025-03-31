using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Filters
{
    public interface IFilter
    {
        public bool CompliantToFilter(IFilterable filterableEntity);
    }
}
