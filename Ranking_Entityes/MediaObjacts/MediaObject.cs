using RankingEntityes.IO_Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Ranking_Entityes.MediaObjacts
{
    public class MediaObject : IO_Entities.Interfaces.ISerializable, IDeserializable
    {
        public Guid ID { get; set; }
        public string Description {  get; set; } = String.Empty;
        public string Tytle { get; set; } = String.Empty;
        public List<string> Paths { get; set; }
        public MediaObject()
        {
            Paths = new List<string>();
            Paths.Add(@"\AppResources\PowerOffButtonIcon.png");
        }
        public bool Deserialize(IDeserializer deserializer, string path)
        {
            throw new NotImplementedException();
        }

        public bool Serialize(ISerializer Serializer, string path)
        {
            throw new NotImplementedException();
        }
    }
}
