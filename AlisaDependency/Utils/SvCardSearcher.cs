using AlisaDependency.Datas;
using AlisaDependency.DataTypes.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.Utils
{
    public static class SvCardSearcher
    {
        public static List<SVCardInfo> Search(string what)
        {
            var ret = new List<SVCardInfo>();
            try
            {
                foreach (var card in StaticDatas.SVCardInfos)
                {
                    if (card.ChineseName!.Contains(what))
                    {
                        ret.Add(card);
                    }
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }
        public static SVCardInfo SearchWithId(string id)
        {
            var ret =new SVCardInfo();
            foreach(var card in StaticDatas.SVCardInfos)
            {
                if(card.Id==long.Parse(id))
                {
                    ret=card;
                }
            }
            return ret;
        }
    }
}
