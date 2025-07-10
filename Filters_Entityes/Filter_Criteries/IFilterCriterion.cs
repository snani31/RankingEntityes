
namespace RankingEntityes.Filters
{
    public interface IFilterCriterion
    {
        public IEnumerable<Filter> Filters { get; set; }
    }
}
