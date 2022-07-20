using AlisaDependency.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.DataTypes.Infos
{
    public class GroupInfo
    {
        public long num;
        public int repeatFrequency;
        public bool manage;
        public int cao;
        public int wenHao;
        public bool seTu;
        public int r18;
        public bool game;
        public bool isYydz;
        public bool isSzb;
        public bool inBlackList;

        public bool canShortCommand;
        public GroupInfo(long num)
        {
            this.num = num;
            this.repeatFrequency = 200;
            this.manage = false;
            this.cao = -1;
            this.wenHao = -1;
            this.seTu = false;
            this.r18 = 0;
            this.game = false;
            this.isYydz = false;
            this.isSzb = true;
            this.inBlackList = false;
            this.canShortCommand = true;
        }
        public GroupInfo(object[] obj)
        {
            num = Convert.ToInt64(obj[0]);
            repeatFrequency = Convert.ToInt32(obj[1]);
            manage = Convert.ToBoolean(obj[2]);
            cao = Convert.ToInt32(obj[3]);
            wenHao = Convert.ToInt32(obj[4]);
            seTu = Convert.ToBoolean(obj[5]);
            r18 = Convert.ToInt32(obj[6]);
            game = Convert.ToBoolean(obj[7]);
            isYydz = Convert.ToBoolean(obj[8]);
            isSzb = Convert.ToBoolean(obj[9]);
            inBlackList = Convert.ToBoolean(obj[10]);
            canShortCommand = Convert.ToBoolean(obj[11]);
        }
        public bool Fresher()
        {
            bool ret = false;
            if (cao == 1)
            {
                cao = 0;
                ret = true;
            }
            if (wenHao == 1)
            {
                wenHao = 0;
                ret = true;
            }
            return ret;
        }
        public string OutDbAddText()
        {
            var ret = $"INSERT INTO groupinfos(num,repeatFrequency,manage,cao,wenHao,seTu,r18,game,isYydz,isSzb,inBlackList,canShortCommand)" +
                $" VALUES(" +
                $"{num}," +
                $"{repeatFrequency}," +
                $"{Convert.ToInt32(manage)}," +
                $"{cao}," +
                $"{wenHao}," +
                $"{Convert.ToInt32(seTu)}," +
                $"{r18}," +
                $"{Convert.ToInt32(game)}," +
                $"{Convert.ToInt32(isYydz)}," +
                $"{Convert.ToInt32(isSzb)}," +
                $"{Convert.ToInt32(inBlackList)}," +
                $"{Convert.ToInt32(canShortCommand)});";
            Logger.Log(ret, 2);

            return ret;
        }
    }
}
