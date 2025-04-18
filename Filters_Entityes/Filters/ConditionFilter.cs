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

        public override bool CompliantToFilter(IFilterable filterableObj)
        {
            Filter? correspondingFilter = filterableObj.MatchFilters.
                FirstOrDefault(filter => filter.IsMatchByID(this)) ?? null;

            if (correspondingFilter is not null)
            {
                return true;
            }
            return false;
        }

        public override Filter DeepClone()
        {
            Filter? clonableResult = new ConditionFilter()
            {
                ID = this.ID,
                ConditionTytle = this.ConditionTytle,
            }; ;

            return clonableResult;
        }

        public override bool Equals(object? obj)
        {
            //bool? elementsIsEquals = null;
            //if (obj is ConditionFilter filter)
            //{
            //    return (this.IsMatchByID(filter) && this.ConditionTytle.Equals(filter.ConditionTytle));
            //}
            //return elementsIsEquals ?? throw new ArgumentException("Заданный аргумент не соответствовал требуемому для сравнения" +
            //    $"типу {typeof(ConditionFilter).Name}, вместо этого он был {obj?.GetType().Name ?? null}");

            var a = obj as ConditionFilter;

            if(a is null) return false;

            return (this.IsMatchByID(a) && this.ConditionTytle.Equals(a.ConditionTytle));
        }
    }
}
