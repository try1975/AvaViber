using System.Data.Entity;
using AvaViber.Db.Entities;
using AvaViber.Db.Entities.QueryProcessors;

namespace AvaViber.Db.SqLite.QueryProcessors
{
    public class ChatInfoQuery: TypedQuery<ChatInfoEntity, int>, IChatInfoQuery
    {
        public ChatInfoQuery(DbContext db) : base(db)
        {
        }
    }
}