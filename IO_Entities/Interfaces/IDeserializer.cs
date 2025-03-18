using RankingEntityes.Ranking_Entityes;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.IO_Entities.Interfaces
{
    public interface IDeserializer
    {
        internal IoCollection<T> DeserializeList<T>(string path) where T : IoEntity;
        internal IDeserializable DeserializeScalar<T>(string path) where T : IoEntity;
    }
}
