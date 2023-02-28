using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.DataTypes.Infos
{
    public class SvSearchEventInfo
    {
        public DateTime Creatime;
        public Dictionary<string, string> SearchInfo;
        public SvSearchEventInfo(Dictionary<string,string> infos)
        {
            SearchInfo = infos;
            Creatime= DateTime.Now;
        }
    }
}
