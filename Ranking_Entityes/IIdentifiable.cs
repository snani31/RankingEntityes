
namespace RankingEntityes.Ranking_Entityes
{
    public interface IIdentifiable
    {
        public Guid ID { get; set; }

        public bool IsMatchByID(IIdentifiable identifiableObj);
    }
}
