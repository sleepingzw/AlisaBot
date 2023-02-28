using AlisaDependency.DataTypes.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.Utils
{
    public static class ChatCommandLoader
    {
        public static Type? GroupCommands;
        static ChatCommandLoader()
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(GlobalConfigs.GroupCommandDll);
                var types = assembly.GetTypes();
                
                foreach(var type in types)
                {
                    if (type.Name == "GroupChatCommands")
                    {
                        GroupCommands = type;
                    }
                }
                if (GroupCommands == null)
                {
                    throw new Exception("没有找到群聊命令模组");
                }
                Logger.Log($"{GroupCommands.Name} 加载成功", 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
