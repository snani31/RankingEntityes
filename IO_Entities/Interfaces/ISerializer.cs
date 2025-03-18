using RankingEntityes.Ranking_Entityes;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.IO_Entities.Interfaces
{
    public interface ISerializer
    {
        internal bool SerializeScalar(ISerializable sender,string path, FileMode mode);
        internal bool SerializeList<T>(IoCollection<T> sender, string path, FileMode mode) 
            where T : IoEntity;
    }
}
