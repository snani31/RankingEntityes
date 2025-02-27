using RankingEntityes.IO_Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.IO_Entities.Interfaces
{
    public interface ISerializable
    {
        public bool Serialize(ISerializer Serializer, string path, FileMode mode);
    }
}
