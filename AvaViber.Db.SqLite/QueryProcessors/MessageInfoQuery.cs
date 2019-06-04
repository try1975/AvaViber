using System.Data.Entity;
using AvaViber.Db.Entities;
using AvaViber.Db.Entities.QueryProcessors;

namespace AvaViber.Db.SqLite.QueryProcessors
{
    public class MessageInfoQuery: TypedQuery<MessageInfoEntity, int>, IMessageInfoQuery
    {
        public MessageInfoQuery(DbContext db) : base(db)
        {
        }
    }
}