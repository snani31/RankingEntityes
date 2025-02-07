using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.IO_Entities.Interfaces
{
    public interface IDeserializable
    {
        public bool Deserialize(IDeserializer deserializer, string path);
    }
}
