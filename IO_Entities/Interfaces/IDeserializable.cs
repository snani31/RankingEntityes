
namespace RankingEntityes.IO_Entities.Interfaces
{
    public interface IDeserializable
    {
        public bool Deserialize(IDeserializer deserializer, string path);
    }
}
