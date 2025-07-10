using RankingEntityes.IO_Entities.Interfaces;
using RankingEntityes.Ranking_Entityes;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;
namespace RankingEntityes.IO_Entities.Classes
{
    public abstract class Deserializer : IDeserializer
    {
        public abstract IoCollection<T> DeserializeList<T>(string path) where T : IoEntity;
        public abstract IDeserializable DeserializeScalar<T>(string path) where T : IoEntity;
    }
}
