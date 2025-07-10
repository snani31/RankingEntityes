using RankingEntityes.IO_Entities.Interfaces;

namespace RankingEntityes.Ranking_Entityes
{
    public abstract class IoEntity : ISerializable, IDeserializable, IIdentifiable
    {
        public Guid ID { get; set; }

        public abstract bool Deserialize(IDeserializer deserializer, string path);

        public bool IsMatchByID(IIdentifiable identifiableObj)
        {
            return identifiableObj.ID.Equals(this.ID);
        }

        public abstract bool Serialize(ISerializer Serializer, string path, FileMode mode);
    }
}
