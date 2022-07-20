using AlisaDependency.Datas;
using AlisaDependency.DataTypes.Infos;
using SlpzLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.Datas
{
    public static class StaticDatas
    {
        private const string EroResponsesAddress = "C:\\AlisaBot\\StaticData\\EroResponses.json";
        private const string BotInfoAddress = "C:\\AlisaBot\\StaticData\\BotInfo.json";
        private const string SVCardInfoAddress = "C:\\AlisaBot\\StaticData\\SVCardInfos.json";

        public static Dictionary<string, List<string>> EroResponses =
            DataOperator.GetJsonFile<Dictionary<string, List<string>>>(EroResponsesAddress);
        public static BotInfo BotInfo =
            DataOperator.GetJsonFile<BotInfo>(BotInfoAddress);
        public static List<SVCardInfo> SVCardInfos =
            DataOperator.GetJsonFile<List<SVCardInfo>>(SVCardInfoAddress);
    }
}
