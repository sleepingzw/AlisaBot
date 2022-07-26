using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using AlisaDependency.DataTypes.Configs;
using AlisaDependency.DataTypes.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;

namespace AlisaDependency.Utils;

/*
public static class ForwardMessageBuilder
{
    internal static string GetUnixTimeStamp()
    {
        DateTime dtStart = new DateTime(1970, 1, 1).ToLocalTime();
        DateTime dtNow = DateTime.Parse(DateTime.Now.ToString());
        TimeSpan toNow = dtNow.Subtract(dtStart);
        string timeStamp = toNow.Ticks.ToString();
        timeStamp = timeStamp[..^7];
        return timeStamp;
    }
    internal static ForwardMessage? BuildForwardMessage(this IEnumerable<MessageChain> messages, IEnumerable<ForwardNodeInfo>? forwardNodeInfos = null)
    {
        var forwardMessage = new ForwardMessage();
        var messagesList = messages.ToList();
        List<ForwardMessage.ForwardNode> forwardNodes = new();
        foreach (var messageChain in messages)
        {
            var node = new ForwardMessage.ForwardNode();
            bool parseFlag = false;
            if (forwardNodeInfos != null)
            {
                var forwardNodeInfo = forwardNodeInfos.ElementAtOrDefault(messagesList.IndexOf(messageChain));
                if (forwardNodeInfo != null)
                {
                    node.MessageChain = forwardNodeInfo.Content;
                    node.SenderId = forwardNodeInfo.SenderId;
                    node.SenderName = forwardNodeInfo.SenderName;
                    if (string.IsNullOrWhiteSpace(forwardNodeInfo.Time))
                    {
                        node.Time = GetUnixTimeStamp();
                    }
                    else
                    {
                        node.Time = forwardNodeInfo.Time;
                    }
                    parseFlag = true;
                }
            }
            if (!parseFlag)
            {
                node.MessageChain = messageChain;
                var sourceMessage = messageChain.OfType<SourceMessage>().FirstOrDefault();
                if (sourceMessage != null)
                {
                    node.SourceId = sourceMessage.MessageId;
                    node.Time = sourceMessage.Time;
                    var info = GetMessageInfoById(sourceMessage.MessageId);
                    if (info.Length > 0)
                    {
                        node.SenderId = info[0]; //target id
                        node.SenderName = info[1]; //target name
                    }
                    else
                    {
                        // Bot.WriteLine("failed to get message info.", ConsoleColor.DarkYellow);
                    }
                    parseFlag = true;
                }
            }
            if (parseFlag)
            {
                forwardNodes.Add(node);
            }
        }
        if (forwardNodes.Count == 0)
        {
            // Bot.WriteLine("failed to build forward message.", ConsoleColor.DarkYellow);
            return null;
        }
        forwardMessage.NodeList = forwardNodes;
        return forwardMessage;
    }
    internal record ForwardNodeInfo
    {
        public MessageChain Content { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string Time { get; set; }
    }
}
*/