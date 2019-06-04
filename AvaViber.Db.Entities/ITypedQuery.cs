using System.Linq;

namespace AvaViber.Db.Entities
{
    public interface ITypedQuery<T, in TK> where T : class, IEntity<TK>
    {
        IQueryable<T> GetEntities();
        T GetEntity(TK id);
    }
}