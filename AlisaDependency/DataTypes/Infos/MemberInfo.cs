using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.DataTypes.Infos
{
    public class MemberInfo
    {
        public long num;
        public int token;
        public int work;
        public int prem;

        public bool inBlackList;
        public MemberInfo(long num)
        {
            this.num = num;
            token = 0;
            work = 0;
            prem = 0;
            inBlackList = false;
        }
        public MemberInfo(object[] obj)
        {
            num = Convert.ToInt64(obj[0]);
            token = Convert.ToInt32(obj[1]);
            work = Convert.ToInt32(obj[2]);
            prem = Convert.ToInt32(obj[3]);
            inBlackList = Convert.ToBoolean(obj[4]);
        }
        public string OutDbAddText()
        {
            var ret = $"INSERT INTO memberinfos(num,token,work,prem,inBlackList)" +
                $" VALUES(" +
                $"{num}," +
                $"{token}," +
                $"{work}," +
                $"{prem}," +
                $"{Convert.ToInt32(inBlackList)});";
            return ret;
        }
    }
}
