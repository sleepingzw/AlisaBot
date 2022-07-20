using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Modules;
using Mirai.Net.Utils.Scaffolds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.Modules
{
    public class FriendModule : IModule
    {
        public bool? IsEnable { get; set; }

        public async void Execute(MessageReceiverBase receiver)
        {
            if (receiver is FriendMessageReceiver Freceiver)
            {
                await Freceiver.SendMessageAsync("不支持私聊，有问题请加用户反馈群939534606");
            }
        }
    }
}
