using IC.LMS.Domain;
using IC.LMS.Domain.Dto;

namespace IC.LMS.Business.Contract
{
    public interface IUserDetail
    {
        int AddUser(UserDetailDto signUpDto);
        UserDetail GetUserDetailsByUsername(string userName);
    }
}
