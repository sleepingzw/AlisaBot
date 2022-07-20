using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.Utils
{
    public static class UsefulMethods
    {
        public static T GetRandomFromList<T>(List<T> list)
        {
            var rr = new Random().Next() % list.Count;
            return list[rr];
        }
    }
}
