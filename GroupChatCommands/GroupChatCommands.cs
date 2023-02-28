using AlisaDependency.DataTypes;
using AlisaDependency.DataTypes.Infos;
using AlisaDependency.Utils;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using SlpzLibrary;

namespace GroupChatCommands
{
    public class GroupChatCommands
    {
        [ChatCommand("艾丽莎在吗", "/alisa", false)]
        public static async Task IsBotHere(GroupMessageReceiver g, ReceiverInfo r)
        {
            await g.SendMessageAsync("我在这~");
        }
    }
}