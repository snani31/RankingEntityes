using RankingEntityes.IO_Entities.Classes;
using RankingEntityes.IO_Entities.Interfaces;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;
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
        }
        public bool Deserialize(IDeserializer deserializer, string path)
        {
            if (deserializer.DeserializeScalar<MediaObject>(path) is MediaObject mediaObject)
            {
                (ID, Description, Tytle, Paths) = mediaObject;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Serialize(ISerializer serializer, string path)
        {
            try
            {
                serializer.SerializeScalar(this, path);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public void Deconstruct(out Guid id, out string description, out string tytle,out List<string> paths)
        {
            id = ID;
            description = Description;
            tytle = Tytle;
            paths = Paths;
        }

    }
}
 