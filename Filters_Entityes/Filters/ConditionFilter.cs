using RankingEntityes.IO_Entities.Interfaces;
using RankingEntityes.Ranking_Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Filters
{
    public class ConditionFilter : Filter
    {
        public ConditionFilter() { }
        public ConditionFilter(string conditionTytle)
        {
            ConditionTytle = conditionTytle;
        }

        public string ConditionTytle { get; set; }

        public override bool CompliantToFilter(IFilterable filterableEntity)
        {
            Filter correspondingFilter = filterableEntity.MatchFilters.
                First(filter => filter.ID.Equals(this.ID));

            if (correspondingFilter.Equals(this))
            {
                return true;
            }
            return false;
        }
    }
}
