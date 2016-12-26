using Microsoft.AspNet.Identity.EntityFramework;

namespace IC.LMS.Data.Base.IBaseRepository
{
    public interface IUnitOfWork
    {
        int Save();
    }
}
