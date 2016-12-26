using IC.LMS.Domain.EnumContract;
using System;

namespace IC.LMS.Domain.Dto
{
    public class UserDetailDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Gender Gender { get; set; }
        public int? CountryId { get; set; }
        public DateTime? Dob { get; set; }
        public int LoginId { get; set; }
      
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
