using RankingEntityes.IO_Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Ranking_Entityes
{
    public abstract class IoEntity : ISerializable, IDeserializable
    {
        public Guid ID { get; set; }

        public abstract bool Deserialize(IDeserializer deserializer, string path);

        public abstract bool Serialize(ISerializer Serializer, string path, FileMode mode);
    }
}
