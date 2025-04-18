using RankingEntityes.Json.Converters;
using RankingEntityes.Ranking_Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Filters
{
    public abstract class Filter : IIdentifiable, IFilter, ITypeTytleContains, IClonableDeep<Filter>
    {
        public Guid ID { get; set; }

        public string TypeName 
        { 
            get 
            {
                return this.GetType().Name;
            } 
        }

        public abstract bool CompliantToFilter(IFilterable filterableEntity);

        public bool IsMatchByID(IIdentifiable identifiableObj)
        {
            return identifiableObj.ID.Equals(this.ID);
        }

        public abstract Filter DeepClone();
    }
}
