using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Ranking_Entityes
{
    public interface IHasSearchedKeyWords
    {
        public List<string> GetSearchDataWords();
    }
}
