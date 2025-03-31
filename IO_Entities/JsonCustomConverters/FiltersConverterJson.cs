using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RankingEntityes.Filters;
using RankingEntityes.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Json.Converters
{
    public class FiltersConverterJson : BaseJsonConverter
    {
        public FiltersConverterJson() : base()
        {
            SpecifiedSubclassConversion = new JsonSerializerSettings()
            {
                ContractResolver = new BaseSpecifiedConcreteClassConverter<Filter>()
            };
        }

        public void Register<TFilterType>(string typeKey) where TFilterType : Filter
        {
            if (Mapping.ContainsKey(typeKey))
            {
                throw new ArgumentException($"Key {typeKey} Was already mapped to the {Mapping[typeKey]}");
            }
            Mapping.Add(typeKey, typeof(TFilterType));
        }

        public override bool CanConvert(Type objectType)
        {
            bool ConvertableMembersTypeIsImplementingITypeTytleContains =
                objectType.GetInterfaces().Any(
                    x => x.Equals(typeof(ITypeTytleContains)));

            return (objectType.Equals(typeof(Filter)) && ConvertableMembersTypeIsImplementingITypeTytleContains);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject tempJsonDeserializableObject = JObject.Load(reader);

            string typeKeyName = tempJsonDeserializableObject[PROPERTY_NAME_OF_CONVERTABLE_ELEMENT_TYPE].Value<string>();

            if (Mapping.ContainsKey(typeKeyName)) return
                JsonConvert.DeserializeObject(
                    tempJsonDeserializableObject.ToString(), Mapping[typeKeyName], SpecifiedSubclassConversion);

            return null;
        }
    }
}
