using RankingEntityes.Filters;
using RankingEntityes.IO_Entities.Classes;
using RankingEntityes.IO_Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Filters
{
    public class ConditionFilterCriterion : FilterCriterion
    {
        public override bool Deserialize(IDeserializer deserializer, string path)
        {
            throw new NotImplementedException();
        }

        public override bool Serialize(ISerializer serializer, string path, FileMode mode)
        {
            try
            {
                serializer.SerializeScalar(this, path, mode);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
