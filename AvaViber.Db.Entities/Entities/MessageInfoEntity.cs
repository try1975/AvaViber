using AvaViber.Common.Enums;

namespace AvaViber.Db.Entities
{
    public class MessageInfoEntity: IEntity<int>
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public ChatInfoEntity Chat { get; set; }
        public MessageType MessageType { get; set; }
        public long TimeStamp { get; set; }

        public string Body { get; set; }
        public string ThumbnailPath { get; set; }
        public string PayloadPath { get; set; }

    }
}