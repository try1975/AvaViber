using System.ComponentModel.DataAnnotations;

namespace SqLiteTest
{
    public class MessageInfoEntity
    {
        [Key]
        public int EventId { get; set; }
        public int ChatId { get; set; }
        public long TimeStamp { get; set; }

        public string Body { get; set; }

    }
}