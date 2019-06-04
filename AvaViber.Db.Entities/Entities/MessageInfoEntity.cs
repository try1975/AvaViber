namespace AvaViber.Db.Entities
{
    public class MessageInfoEntity: IEntity<int>
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public long TimeStamp { get; set; }

        public string Body { get; set; }

    }
}