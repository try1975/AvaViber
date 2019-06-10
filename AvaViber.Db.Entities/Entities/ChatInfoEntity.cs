using System.Collections.Generic;

namespace AvaViber.Db.Entities
{
    public class ChatInfoEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MessageInfoEntity> MessagesInfo { get; set; }
    }
}