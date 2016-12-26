using IC.LMS.Business.Contract;
using IC.LMS.Data.Base;
using IC.LMS.Data.Tier.Repository;
using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using System.Linq;

namespace IC.LMS.Business
{
    public class UserDetailImpl : IUserDetail
    {
        private readonly UserDetailRepository _userDetailRepository;

        public UserDetailImpl()
        {
            _userDetailRepository = new UserDetailRepository();
        }
        public int AddUser(UserDetailDto signUpDto)
        {
            if (signUpDto != null)
            {
                UserDetail userDetail = new UserDetail
                {
                    FirstName = signUpDto.FirstName,
                    LastName = signUpDto.LastName,
                    Email = signUpDto.Email,
                    ContactNo = signUpDto.ContactNo,
                    Gender = signUpDto.Gender,
                    CountryId = signUpDto.CountryId,
                    Dob = signUpDto.Dob
                };
                return _userDetailRepository.Add(userDetail).UserId;
            }
            else
            {
                return 0;
            }
        }
        public UserDetail GetUserDetailsByUsername(string userName)
        {
            return _userDetailRepository.GetAll(hp => hp.fk_UserId.ToLower() == userName.ToLower().Trim()).FirstOrDefault();
        }
    }
}
