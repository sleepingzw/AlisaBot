using Mirai.Net.Data.Messages.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.DataTypes.Infos
{
    public class ReceiverInfo
    {
        public bool CanCommand;
        public GroupInfo Group;
        public MemberInfo Member;
        public string AllPlainMessage;        
        public string[] PlainMessages;
        public AtMessage[] AtMessages;
        public ImageMessage[] ImageMessages;
        public bool AtMe;
        public bool IsOwner;
        public bool inblackg, inblackm;

        public ReceiverInfo(bool CanCommand,GroupInfo group, MemberInfo member, string allPlainMessage, string[] plainMessages, AtMessage[] atMessages, ImageMessage[] imageMessages, bool atMe, bool isOwner, bool inblackg, bool inblackm)
        {
            this.CanCommand = CanCommand;
            Group = group;
            Member = member;
            AllPlainMessage = allPlainMessage;
            PlainMessages = plainMessages;
            AtMessages = atMessages;
            ImageMessages = imageMessages;
            AtMe = atMe;
            IsOwner = isOwner;
            this.inblackg = inblackg;
            this.inblackm = inblackm;
        }

    }
}
