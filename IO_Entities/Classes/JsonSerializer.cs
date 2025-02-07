using Newtonsoft.Json;
using RankingEntityes.IO_Entities.Interfaces;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.IO_Entities.Classes
{
    public class JsonSerializer : Serializer
    {
        public override bool SerializeList<T>(IoCollection<T> sender, string path)
        {
            if (File.Exists(path))
            {
                foreach (T item in sender)
                {
                    File.AppendAllText(path, JsonConvert.SerializeObject(item));
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        public override bool SerializeScalar(ISerializable sender, string path)
        {
            if (File.Exists(path))
            {
                File.AppendAllText(path, JsonConvert.SerializeObject(sender));
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
