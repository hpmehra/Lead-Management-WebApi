using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace IC.LMS.Data.Base
{
    public class BaseRepository<T> : Base<T>
       where T : class
    {
        public BaseRepository()
        {
            this.dbset = Context.Set<T>();
        }

        protected virtual void SetEntityState(object entity, EntityState entityState)
        {
            this.Context.Entry(entity).State = entityState;
        }

        public virtual int Update(T item)
        {
            this.dbset.Attach(item);
            dbContext.Entry(item).State = EntityState.Modified;
            //this.Context.SaveChanges();
            return this.Save();
        }

        public virtual int Update(T item, params Expression<Func<T, object>>[] properties)
        {
            this.dbset.Attach(item);
            DbEntityEntry<T> entry = dbContext.Entry(item);
            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
            return this.Save();
        }
    }
}
