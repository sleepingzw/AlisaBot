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
        public static Dictionary<string, SvSearchEventInfo> svSearchEvents=new Dictionary<string, SvSearchEventInfo>();
        public static Dictionary<string, SvRoomInfo> svRoomInfos = new Dictionary<string, SvRoomInfo>();

        public static void CreateSvRoomInfoEvent(SvRoomInfo info)
        {
            svRoomInfos.Add($"{info.whatServer}-{info.whatServer}",info);
            TaskHolder.AddSvRoomWaitTask(300, $"{info.whatServer}-{info.whatServer}", info.createTime);
        }

        public static void DisposeSvRoomInfoEvent(string key, DateTime dt)
        {
            if (svRoomInfos.ContainsKey(key))
            {
                if (svRoomInfos[key].createTime == dt)
                {
                    svRoomInfos.Remove(key);
                }
            }
        }
        public static void CreateSvSearchEvent(string groupNum, string memberNum, SvSearchEventInfo info)
        {
            svSearchEvents.Add($"{groupNum}-{memberNum}", info);
            TaskHolder.AddSvSearchWaitTask(10, $"{groupNum}-{memberNum}",info.Creatime);
        }
        public static void DisposeSvSearchEvent(string key,DateTime dt)
        {
            if (svSearchEvents.ContainsKey(key))
            {
                if (svSearchEvents[key].Creatime == dt)
                {
                    svSearchEvents.Remove(key);
                }
            }
        }
    }
}
