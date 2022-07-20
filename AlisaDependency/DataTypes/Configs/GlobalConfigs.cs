using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlpzLibrary;

namespace AlisaDependency.DataTypes.Configs
{
    public static class GlobalConfigs
    {
        private const string DataBaseConfigAddress = "C://AlisaBot//Config//DataBaseConfig.json";
        private const string BotConfigAddress = "C://AlisaBot//Config//BotConfig.json";

        public const string GroupCommandDll = "C://AlisaBot//Commands//GroupChatCommands.dll";
        public static DataBaseConfig DataBaseConfig
            = DataOperator.GetJsonFile<DataBaseConfig>(DataBaseConfigAddress);
        public static BotConfig BotConfig
            = DataOperator.GetJsonFile<BotConfig>(BotConfigAddress);
    }
}
