using IC.LMS.Domain.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace IC.LMS.Business.Contract
{
    public interface IUserLogin
    {
        Task<IdentityResult> RegisterUser(UserDetailDto userDetailDto);
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
