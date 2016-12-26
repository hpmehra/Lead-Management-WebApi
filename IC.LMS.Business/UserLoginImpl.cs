using IC.LMS.Business.Contract;
using IC.LMS.Data.Tier.IRepository;
using IC.LMS.Data.Tier.Repository;
using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Omu.ValueInjecter;
using System.Threading.Tasks;

namespace IC.LMS.Business
{
    public class UserLoginImpl : IUserLogin
    {
        private UserLoginRepository _userLoginRepository;
        private readonly IUserDetailRepository _userDetailRepository;

        public UserLoginImpl()
        {
            _userLoginRepository = new UserLoginRepository();
            _userDetailRepository = new UserDetailRepository();
        }

        public async Task<IdentityResult> RegisterUser(UserDetailDto userDetailDto)
        {
           var result= await _userLoginRepository.RegisterUser(Mapper.Map<UserModelDto>(userDetailDto));

            if (result.Succeeded)
            {
                var userDetails = Mapper.Map<UserDetail>(userDetailDto);
                userDetails.fk_UserId = userDetailDto.UserName;
                _userDetailRepository.Add(userDetails);
            }
            //save other user detail...
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            return await _userLoginRepository.FindUser(userName, password);
        }
        
    }
}
