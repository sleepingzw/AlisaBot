using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.DataTypes.Infos
{
    public class SVCardInfo
    {
        public long Id;
        public long GameId;
        public string? CardType;
        public string? SubType;
        public int ManaCost;
        public string? Job;
        public int Atk;
        public int Hp;
        public string? Effects;
        public string? ChineseName;
        public string? ChineseDescription;
        public string? JapaneseName;
        public string? EnglishName;
        public int Rarity;
        public string? SeriesAbbr;
        public string? SeriesName;
    }
}
