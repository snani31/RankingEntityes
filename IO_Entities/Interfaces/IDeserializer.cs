using RankingEntityes.Ranking_Entityes;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;

namespace RankingEntityes.IO_Entities.Interfaces
{
    public interface IDeserializer
    {
        internal IoCollection<T> DeserializeList<T>(string path) where T : IoEntity;
        internal IDeserializable DeserializeScalar<T>(string path) where T : IoEntity;
    }
}
