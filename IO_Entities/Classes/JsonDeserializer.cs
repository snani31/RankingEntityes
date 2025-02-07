using Newtonsoft.Json;
using RankingEntityes.IO_Entities.Interfaces;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;



namespace RankingEntityes.IO_Entities.Classes
{
    public class JsonDeserializer : Deserializer
    {
        public override IoCollection<T> DeserializeList<T>(string path)
        {
            if (File.Exists(path))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                JsonTextReader reader = new JsonTextReader(new StreamReader(path));
                IoCollection<T> localList = new IoCollection<T>();
                reader.SupportMultipleContent = true;
                while (reader.Read())
                {
                    T timeStrTmp = serializer.Deserialize<T>(reader);
                    localList.Add(timeStrTmp);
                }
                reader.Close();
                return localList;
            }
            else
            {
                return null;
            }
        }

        public override IDeserializable DeserializeScalar<T>(string path)
        {
            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
