using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Ranking_Entityes
{
    public interface IIdentifiable
    {
        public Guid ID { get; set; }
    }
}
