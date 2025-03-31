using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Json.Converters
{
    public abstract class BaseJsonConverter : JsonConverter
    {
        protected const string PROPERTY_NAME_OF_CONVERTABLE_ELEMENT_TYPE = "TypeName";
        protected BaseJsonConverter()
        {
            Mapping = new Dictionary<string, Type>();
        }

        protected IDictionary<string, Type> Mapping { get; init; }

        protected static JsonSerializerSettings SpecifiedSubclassConversion { get; set; }
        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
