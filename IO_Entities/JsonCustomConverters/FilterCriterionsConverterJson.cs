using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RankingEntityes.Filters;

namespace RankingEntityes.Json.Converters
{
    public class FilterCriterionsConverterJson : BaseJsonConverter
    {
        private FiltersConverterJson FiltersConverter { get; init; }
        public FilterCriterionsConverterJson(FiltersConverterJson filtersConverter) : base()
        {
            FiltersConverter = filtersConverter;
        }

        public void Register<TFilterCriterionType>(string typeKey) where TFilterCriterionType : FilterCriterion
        {
            if (Mapping.ContainsKey(typeKey))
            {
                throw new ArgumentException($"Key {typeKey} Was already mapped to the {Mapping[typeKey]}");
            }
            Mapping.Add(typeKey, typeof(TFilterCriterionType));
        }

        public override bool CanConvert(Type objectType)
        {
            bool ConvertableMembersTypeIsImplementingITypeTytleContains = 
                objectType.GetInterfaces().Any(
                    x => x.Equals(typeof(ITypeTytleContains)));

            return (objectType.Equals(typeof(FilterCriterion)) && ConvertableMembersTypeIsImplementingITypeTytleContains);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            string filterName = jo[PROPERTY_NAME_OF_CONVERTABLE_ELEMENT_TYPE].Value<string>();

            if (Mapping.ContainsKey(filterName)) return
                    JsonConvert.DeserializeObject(
                    jo.ToString(), Mapping[filterName], FiltersConverter
                    );

            return null;
        }
    }
}
