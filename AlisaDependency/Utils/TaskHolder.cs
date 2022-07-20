using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlisaDependency.Datas;

namespace AlisaDependency.Utils
{
    public static class TaskHolder
    {
        public static void AddSvSearchWaitTask(int timesec,string key,DateTime dt)
        {
            Task.Run(() =>
            {
                Thread.Sleep(timesec * 1000);
                GlobalVariables.DisposeSvSearchEvent(key,dt);
                Logger.Log($"查询事件 {key} {dt} 已经注销", 1);
            });
        }
    }
}
