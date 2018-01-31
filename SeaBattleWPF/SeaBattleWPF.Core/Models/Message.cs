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

        public Message()
        {
                
        }
    }
}
