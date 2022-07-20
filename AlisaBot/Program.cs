#region bots

using AlisaDependency.DataTypes.Configs;
using AlisaDependency.Modules;
using AlisaDependency.Utils;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using System.Reactive.Linq;

var exit = new ManualResetEvent(false);

using var bot = new MiraiBot
{
    Address = GlobalConfigs.BotConfig.Address,
    VerifyKey = GlobalConfigs.BotConfig.VerifyKey,
    QQ = GlobalConfigs.BotConfig.QQ
};

await bot.LaunchAsync();

Logger.Log("正在工作", 0);

var friendModule = new FriendModule();
var groupModule = new GroupModule();
bot.MessageReceived.OfType<GroupMessageReceiver>().Subscribe(x =>
{
    groupModule.Execute(x);
});
bot.EventReceived.OfType<NewInvitationRequestedEvent>().Subscribe(x =>
{ 
    RequestManager.HandleNewInvitationRequestedAsync(x, NewInvitationRequestHandlers.Approve, "");
});
exit.WaitOne();
#endregion
