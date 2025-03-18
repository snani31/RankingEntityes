using RankingEntityes.IO_Entities.Interfaces;
using RankingEntityes.Ranking_Entityes;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.IO_Entities.Classes
{
    public abstract class Serializer : ISerializer
    {
        public abstract bool SerializeScalar(ISerializable sender, string path, FileMode mode);
        public abstract bool SerializeList<T>(IoCollection<T> sender, string path, FileMode mode) 
            where T : IoEntity;
    }
}
