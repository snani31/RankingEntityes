
namespace RankingEntityes.Filters
{
    public interface IFilter
    {
        public bool CompliantToFilter(IFilterable filterableEntity);
    }
}
