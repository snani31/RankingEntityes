using Newtonsoft.Json;
using RankingEntityes.IO_Entities.Interfaces;
using RankingEntityes.Ranking_Entityes.Ranking_Categories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.IO_Entities.Classes
{
    public class JsonSerializer : Serializer
    {
        public override bool SerializeList<T>(IoCollection<T> sender, string path, FileMode mode)
        {
            try
            {
                // Если передаётся пустая коллекция
                if (sender.ValueArray.Length < 1)
                {
                    // открыть файл по указанному пути с параметром Trunkate и сразу закрыть его, чтобы стереть содержимое
                    using (FileStream fStream = new FileStream(path, FileMode.Truncate, FileAccess.Write));
                }
                else
                {
                    using (FileStream fStream = new FileStream(path, mode, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fStream))
                    {
                        fStream.SetLength(0);
                        foreach (T item in sender) sw.WriteLine(JsonConvert.SerializeObject(item));
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public override bool SerializeScalar(ISerializable sender, string path, FileMode mode)
        {
            try
            {
                using (FileStream fStream = new FileStream(path, mode, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fStream))
                    sw.WriteLine(JsonConvert.SerializeObject(sender));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
