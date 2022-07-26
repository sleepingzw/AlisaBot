using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static void AddSvRoomWaitTask(int timesec, string key, DateTime dt)
        {
            Task.Run(() =>
            {
                Thread.Sleep(timesec * 1000);
                GlobalVariables.DisposeSvRoomInfoEvent(key, dt);
                Logger.Log($"房间事件 {key} {dt} 已经注销", 1);
            });
        }

        public static void DeleteTask(string path)
        {
            Task.Run(() =>
            {
                Thread.Sleep(500);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Logger.Log($"删除 {path} 成功", 1);
                }
                else
                {
                    Logger.Log($"删除 {path} 失败,目标文件不存在", 2);
                }
            });
        }
    }
}
