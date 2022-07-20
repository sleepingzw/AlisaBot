using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlisaDependency.DataTypes.Infos;
using AlisaDependency.Utils;

namespace AlisaDependency.Datas
{
    public static class GlobalVariables
    {
        public static Dictionary<string, SvSearchEventInfo> SvSearchEvents=new Dictionary<string, SvSearchEventInfo>();
        public static void CreateSvSearchEvent(string groupnum, string membernum, SvSearchEventInfo info)
        {
            SvSearchEvents.Add($"{groupnum}-{membernum}", info);
            TaskHolder.AddSvSearchWaitTask(10, $"{groupnum}-{membernum}",info.Creatime);
        }
        public static void DisposeSvSearchEvent(string key,DateTime dt)
        {
            if (SvSearchEvents.ContainsKey(key))
            {
                if (SvSearchEvents[key].Creatime == dt)
                {
                    SvSearchEvents.Remove(key);
                }
            }
        }
    }
}
