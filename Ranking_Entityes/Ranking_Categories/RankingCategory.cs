using RankingEntityes.IO_Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace RankingEntityes.Ranking_Entityes.Ranking_Categories
{
    public class RankingCategory: IO_Entities.Interfaces.ISerializable,IDeserializable
    {
        public RankingCategory() { }

        public Guid ID;
        public string Description;
        public string Tytle;
        public string RankingDirrectoryPath;
        public string RankingIconPath;
        public bool Deserialize(IDeserializer deserializer, string path)
        {
            ///// Необходимо добавить обработку исключений !!!!!
            (ID,Description,Tytle,RankingDirrectoryPath,RankingIconPath) = (RankingCategory)deserializer.DeserializeScalar<RankingCategory>(path);
            return true;
        }

        public bool Serialize(ISerializer serializer, string path)
        {
            try
            {
                serializer.SerializeScalar(this, path);
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
            id = ID;
            description = Description;
            tytle = Tytle;
            rankingDirrectoryPath = RankingDirrectoryPath;
            rankingIconPath = RankingIconPath;
        }
    }
}
