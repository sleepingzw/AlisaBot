using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions.Http.Managers;

namespace AlisaDependency.Utils
{
    public static class UsefulMethods
    {
        public static T GetRandomFromList<T>(List<T> list)
        {
            var rr = new Random().Next() % list.Count;
            return list[rr];
        }

        public static async Task<List<Group>> GroupGetter()
        {
            var groups = await AccountManager.GetGroupsAsync();
            return groups.ToList();
        }
    }
}
