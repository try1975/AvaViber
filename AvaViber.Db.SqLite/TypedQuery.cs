using System.Data.Entity;
using System.Linq;
using AvaViber.Db.Entities;

namespace AvaViber.Db.SqLite
{
    public abstract class TypedQuery<T, TK> : ITypedQuery<T, TK> where T : class, IEntity<TK>
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _entities;

        protected TypedQuery(DbContext db)
        {
            _db = db;
            _entities = _db.Set<T>();
        }

        public virtual IQueryable<T> GetEntities()
        {
            return _entities.AsNoTracking();
        }

        public virtual T GetEntity(TK id)
        {
            var entity = _entities.Find(id);
            return entity;
        }
    }
}