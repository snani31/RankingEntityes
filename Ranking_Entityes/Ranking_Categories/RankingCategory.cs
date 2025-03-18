using RankingEntityes.IO_Entities.Interfaces;

namespace RankingEntityes.Ranking_Entityes.Ranking_Categories
{
    public class RankingCategory: IoEntity
    {
        public RankingCategory() { }

        public string Description;
        public string Tytle;
        public string RankingDirrectoryPath;
        public string RankingIconPath;
        public override bool Deserialize(IDeserializer deserializer, string path)
        {
            if ( deserializer.DeserializeScalar<RankingCategory>(path) is RankingCategory category)
            {
                (base.ID, Description, Tytle, RankingDirrectoryPath, RankingIconPath) = category;
                return true;
            }
            else
            {
                return false;
            }
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
        /// <summary>
        /// Используется для того, чтобы инициализовать новый объект, после десериализации существующего состояния из файла
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="tytle"></param>
        /// <param name="rankingDirrectoryPath"></param>
        /// <param name="rankingIconPath"></param>
        public void Deconstruct(out Guid id, out string description,out string tytle,out string rankingDirrectoryPath,
            out string rankingIconPath)
        {
            id = base.ID;
            description = Description;
            tytle = Tytle;
            rankingDirrectoryPath = RankingDirrectoryPath;
            rankingIconPath = RankingIconPath;
        }
    }
}
