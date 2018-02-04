using System;
using SeaBattleWPF.Core.Enums;

namespace SeaBattleWPF.Core.Models
{
    [Serializable]
    public class Message
    {
        public MessageEnum Info { get; set; }

        public string message { get; set; }

        public Message(MessageEnum messageEnum, int x, int y)
        {
            Info = messageEnum;

            message = $"{x} {y}";
        }

        public Message(MessageEnum messageEnum, string message)
        {
            Info = messageEnum;
            this.message = message;
        }

        public Message(MessageEnum messageEnum)
        {
            Info = messageEnum;
        }

        public Message()
        {
                
        }
    }
}
