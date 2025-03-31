using RankingEntityes.Filters;
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
    public class MediaObject : IoEntity, IFilterable
    {
        public string Description {  get; set; } = String.Empty;
        public string Tytle { get; set; } = String.Empty;
        public List<string> Paths { get; set; }
        public IEnumerable<Filter> MatchFilters { get; set; }

        public MediaObject()
        {
            Paths = new List<string>();
            MatchFilters = new List<Filter>();
        }
        public override bool Deserialize(IDeserializer deserializer, string path)
        {
            if (deserializer.DeserializeScalar<MediaObject>(path) is MediaObject mediaObject)
            {
                (base.ID, Description, Tytle, Paths) = mediaObject;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Serialize(ISerializer serializer, string path, FileMode mode)
        {
            try
            {
                serializer.SerializeScalar(this, path,mode);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private void Deconstruct(out Guid id, out string description, out string tytle,out List<string> paths)
        {
            id = base.ID;
            description = Description;
            tytle = Tytle;
            paths = Paths;
        }

    }
}
 