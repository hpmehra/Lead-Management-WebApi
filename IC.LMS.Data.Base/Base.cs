using IC.LMS.Data.Base.IBaseRepository;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace IC.LMS.Data.Base
{
    public class Base<T>: Disposable
        where T : class
    {
        protected IUnitOfWork UnitOfWork;
        protected IDbSet<T> dbset;

        protected IdentityDbContext dbContext;

        protected DbContext Context
        {
            get { return dbContext ?? (dbContext = new IC.LMS.Data.LMSDataContext()); }
        }

        public virtual IDbSet<T> GetDbSet()
        {
            return this.dbset;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            if (where != null)
                return dbset.AsNoTracking().Where(where);
            else
                return dbset.ToArray();
        }

        public virtual IEnumerable<T> GetAll(int maxRecordCount)
        {
            if (maxRecordCount == -1)
                return dbset.ToList();
            else
                return dbset.Take(maxRecordCount);
        }

        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }

        public virtual T GetById(Guid id)
        {
            return dbset.Find(id);
        }

        public virtual T Add(T item)
        {
            item = dbset.Add(item);
            Save();
            return item;
        }

       

        public virtual int Delete(T item)
        {
            dbset.Remove(item);
           return this.Save();
           
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
            Save();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        protected override void DisposeCore()
        {
            if (Context != null)
                Context.Dispose();
        }

    }
}
