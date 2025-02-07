using RankingEntityes.IO_Entities.Interfaces;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.IO_Entities.Classes
{
    public abstract class Deserializer : IDeserializer
    {
        public abstract IoCollection<T> DeserializeList<T>(string path) where T : IDeserializable, ISerializable;
        public abstract IDeserializable DeserializeScalar<T>(string path) where T : IDeserializable;
    }
}
