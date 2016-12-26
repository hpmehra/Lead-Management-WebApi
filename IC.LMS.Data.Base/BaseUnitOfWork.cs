using IC.LMS.Data.Base.IBaseRepository;
using Microsoft.AspNet.Identity.EntityFramework;


namespace IC.LMS.Data.Base
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private IdentityDbContext dataContext;
         
       

        public BaseUnitOfWork()
        {
            dataContext = DataContext;
        }
      
        protected IdentityDbContext DataContext
        {
            get { return dataContext ?? (new IC.LMS.Data.LMSDataContext()); }
        }

        public int Save()
        {
            return dataContext.SaveChanges();
        }
    }
}
