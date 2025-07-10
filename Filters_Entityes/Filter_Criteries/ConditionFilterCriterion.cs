using RankingEntityes.IO_Entities.Interfaces;

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
