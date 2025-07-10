
namespace RankingEntityes.Filters
{
    public interface IFilterable 
    {
        public IEnumerable<Filter> MatchFilters { get; set; }
    }
}
