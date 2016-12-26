using Microsoft.VisualStudio.TestTools.UnitTesting;
using IC.LMS.Business;
using IC.LMS.Data.Tier.IRepository;
using IC.LMS.Data.Tier.Repository;
using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using IC.LMS.Domain.EnumContract;
using System.Threading.Tasks;

namespace IC.LMS.BusinessTest
{
   
    [TestClass]
    public class UserLoginImplTest
    {
       private UserLoginImpl userLoginImpl;
        [TestInitialize]
        public void UnitTest1Initialize()
        {
            userLoginImpl = new UserLoginImpl();
        }
   
        [TestMethod]
        public async Task UserSignUp()
        {
            UserDetailDto signUpDto = new UserDetailDto
            {
                FirstName = "Dhruv",
                LastName="Singh",
                ContactNo="9888888",
                Email="info@gmail.com",
                Gender=Gender.Male,
                CountryId=1,
                UserName="harry4",
                Password= "SuperPass3",
                ConfirmPassword= "SuperPass3",
                Dob = System.DateTime.Now
            };
            var result = await userLoginImpl.RegisterUser(signUpDto);
            Assert.IsTrue(result.Succeeded, "Add successfully");
        }
    }
}
