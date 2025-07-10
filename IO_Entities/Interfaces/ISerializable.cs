
namespace RankingEntityes.IO_Entities.Interfaces
{
    public interface ISerializable
    {
        public bool Serialize(ISerializer Serializer, string path, FileMode mode);
    }
}
