using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using AlisaDependency.DataTypes.Configs;
using AlisaDependency.DataTypes.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.Utils
{
    public static class MessagePreOperator
    {
        public async static Task<ReceiverInfo> MakeGroupReceiverInfo(GroupMessageReceiver g)
        {
            try
            {
                bool atme = false;
                bool isowner = false;
                bool cancommand = true;
                if (g.MessageChain.GetPlainMessage() == "")
                {
                    cancommand = false;
                }
                if (g.MessageChain.OfType<AtAllMessage>().Any())
                {
                    cancommand = false;
                }
                foreach (AtMessage at in g.MessageChain.OfType<AtMessage>())
                {
                    if (at.Target == GlobalConfigs.BotConfig.QQ)
                    {
                        atme = true;
                        cancommand = true;
                        break;
                    }
                }
                //是否owner
                if (g.Sender.Id == GlobalConfigs.BotConfig.OwnerId)
                {
                    isowner = true;
                }
                var stringlist = new List<string>();
                foreach(var pl in g.MessageChain.GetSeparatedPlainMessage())
                {
                    foreach(var p in pl.Trim().Split(' '))
                    {
                        if (p != " ")
                        {
                            stringlist.Add(p);
                        }
                    }
                }
                return new ReceiverInfo(cancommand,
                    await DataBaseOperator.FindGroup(long.Parse(g.GroupId)),
                    await DataBaseOperator.FindMember(long.Parse(g.Sender.Id)),
                    g.MessageChain.GetPlainMessage(),
                    stringlist.ToArray(),
                    g.MessageChain.OfType<AtMessage>().ToArray(),
                    g.MessageChain.OfType<ImageMessage>().ToArray(),
                    atme,
                    isowner,
                    false,
                    false);
            }
            catch
            {
                throw;
            }
        }
    }
}
