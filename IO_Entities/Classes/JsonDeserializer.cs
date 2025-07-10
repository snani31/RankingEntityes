using Newtonsoft.Json;
using RankingEntityes.IO_Entities.Interfaces;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;

namespace RankingEntityes.IO_Entities.Classes
{
    public class JsonDeserializer : Deserializer
    {
        private Newtonsoft.Json.JsonSerializer Serializer {  get; init; }


        public JsonDeserializer()
        {
            Serializer = new Newtonsoft.Json.JsonSerializer();
        }

        public JsonDeserializer(JsonConverter converter): this()
        {
            Serializer.Converters.Add(converter);
        }

        public override IoCollection<T> DeserializeList<T>(string path)
        {
            if (File.Exists(path))
            {
                IoCollection<T> localList = new IoCollection<T>();

                using (StreamReader streamReader = new StreamReader(path))
                {
                    using (JsonTextReader jsonReader = new JsonTextReader(streamReader))
                    {
                        jsonReader.SupportMultipleContent = true;
                        while (jsonReader.Read())
                        {
                            T timeStrTmp = Serializer.Deserialize<T>(jsonReader);
                            localList.Add(timeStrTmp);
                        }
                        jsonReader.Close();
                    }
                }
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
