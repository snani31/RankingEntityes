using RankingEntityes.Json.Converters;
using RankingEntityes.Ranking_Entityes;

namespace RankingEntityes.Filters
{
    public abstract class FilterCriterion : IoEntity, IFilterCriterion, ITypeTytleContains
    {
        public string Tytle { get; set; }
        public string Description { get; set; }

        public string TypeName
        {
            get
            {
                return this.GetType().Name;
            }
        }
        public IEnumerable<Filter> Filters { get; set; }
    }
}
