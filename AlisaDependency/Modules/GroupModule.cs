using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Modules;
using Mirai.Net.Utils.Scaffolds;
using AlisaDependency.Utils;
using AlisaDependency.Datas;
using SlpzLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace AlisaDependency.Modules
{
    public class GroupModule : IModule
    {
        public bool? IsEnable { get; set; }

        public async void Execute(MessageReceiverBase receiver)
        {
            try
            {
                if (receiver is GroupMessageReceiver g)
                {
                    var receiverinfo = await MessagePreOperator.MakeGroupReceiverInfo(g);
                    foreach (var tt in receiverinfo.PlainMessages)
                    {
                        Logger.Log(tt, 0);
                    }
                    //最优先响应存放于字典中的跨事件交互
                    if (receiverinfo.CanCommand && GlobalVariables.svSearchEvents.ContainsKey($"{g.GroupId}-{g.Sender.Id}"))
                    {
                        foreach (var methodInfo in GetCommandHandlers())
                        {
                            var info = methodInfo.GetCustomAttribute<ChatCommandAttribute>()!;
                            foreach (var st in info.ShortTrigger)
                            {
                                if (info.SpecialAct == "SvSearchEvent")
                                {
                                    await (Task)methodInfo.Invoke(null, new object[] { g, receiverinfo })!;
                                    return;
                                }
                            }
                        }
                    }
                    //短命令 无视at
                    if (receiverinfo.Group.canShortCommand && receiverinfo.CanCommand)
                    {
                        foreach (var methodInfo in GetCommandHandlers())
                        {
                            var info = methodInfo.GetCustomAttribute<ChatCommandAttribute>()!;
                            foreach (var st in info.ShortTrigger)
                            {
                                if (
                                    info.SpecialAct == ""
                                    && receiverinfo.PlainMessages[0].ToLower() == st)
                                {
                                    await (Task)methodInfo.Invoke(null, new object[] { g, receiverinfo })!;
                                    return;
                                }
                            }
                        }
                    }
                    //正常命令 需要符合at
                    if (receiverinfo.CanCommand)
                    {
                        foreach (var methodInfo in GetCommandHandlers())
                        {
                            var info = methodInfo.GetCustomAttribute<ChatCommandAttribute>()!;
                            foreach (var ct in info.CommandTrigger)
                            {
                                if (
                                    info.SpecialAct == ""
                                    && receiverinfo.PlainMessages[0].ToLower() == ct
                                    && info.IsAt == receiverinfo.AtMe)
                                {
                                    await (Task)methodInfo.Invoke(null, new object[] { g, receiverinfo })!;
                                    return;
                                }
                            }
                        }
                    }
                    //其他命令 最后匹配 需要有SpecialAct 并且满足at
                    if (receiverinfo.CanCommand)
                    {
                        foreach (var methodInfo in GetCommandHandlers())
                        {
                            var info = methodInfo.GetCustomAttribute<ChatCommandAttribute>()!;
                            if (info.SpecialAct == "EroResponses"
                                && info.IsAt == receiverinfo.AtMe)
                            {
                                await (Task)methodInfo.Invoke(null, new object[] { g, receiverinfo })!;
                                return;
                            }
                        }
                        foreach (var methodInfo in GetCommandHandlers())
                        {
                            var info = methodInfo.GetCustomAttribute<ChatCommandAttribute>()!;
                            if (info.SpecialAct == "PureAt"
                                && info.IsAt == receiverinfo.AtMe)
                            {
                                await (Task)methodInfo.Invoke(null, new object[] { g, receiverinfo })!;
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
        private static IEnumerable<MethodInfo> GetCommandHandlers()
        {
            return ChatCommandLoader.GroupCommands!
                .GetMethods()
                .Where(x => x.GetCustomAttribute<ChatCommandAttribute>() != null);
        }
    }
}
