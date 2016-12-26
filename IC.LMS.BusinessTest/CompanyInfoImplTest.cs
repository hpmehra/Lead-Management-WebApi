using Microsoft.VisualStudio.TestTools.UnitTesting;
using IC.LMS.Business;
using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using IC.LMS.Domain.EnumContract;
using System.Collections;
using Newtonsoft.Json;

namespace IC.LMS.BusinessTest
{
    [TestClass]
    public class CompanyInfoImplTest
    {
        CompanyInfoImpl companyInfoImplObj;
        [TestInitialize]
        public void UnitTest1Initialize()
        {
            companyInfoImplObj=    new CompanyInfoImpl();
        }

        [TestMethod]
        public void GetCompanyInfoAll()
        {
            var result = companyInfoImplObj.GetCompanyInfoAll();
            Assert.IsTrue(result != null, "Get all");
        }

        [TestMethod]
        public void AddCompanyInfo()
        {

            CompanyInfoDto companyInfoDto = new CompanyInfoDto
            {
                CompanyName = "TestComapny",
                CompanyWebsite = "abc.com",             
                Status = Status.IsLead,
                CreateOn = System.DateTime.Now,
                SourceName = "Client referral",
                DeadReason ="Dead reason",
                CompanyAddress="noida 62 near ignu",
                CompanyContactNo="875496545",
                PostalCode="452666",
                FaxNo=455555,
                CompanyEmailId = "test@info.com",
                SuccessScore=1,
                LinkedInUrl="info_couture",
                CountryId = 1,
                PrimaryPersonName="primary person",
                PrimaryPersonEmailId="primary@gmail.com",
                PrimaryPersonContactNo="458545555",
                PrimaryPersonSkypeId="primaryskype",
                SecondaryPersonName="secondary person",
                SecondaryPersonEmailId="secondary@gmail.com",
                SecondaryPersonContactNo="895476255",
                SecondaryPersonSkypeId="seconadryskype"

            };
           var result= companyInfoImplObj.AddCompanyInfo(companyInfoDto);
            Assert.IsTrue(result>0, "Add successfully");
        }


        [TestMethod]
        public void AddCompanyInfoExcel()
        {

            CompanyInfoDto companyInfoDto = new CompanyInfoDto
            {
                CompanyName = "TestComapny",
                CompanyWebsite = "abc.com",
                Status = Status.IsLead,
                CreateOn = System.DateTime.Now,
                SourceName = "Client referral",
                DeadReason = "Dead reason",
                CompanyAddress = "noida 62 near ignu",
                CompanyContactNo = "875496545",
                PostalCode = "452666",
                FaxNo = 455555,
                CompanyEmailId = "test@info.com",
                SuccessScore = 1,
                LinkedInUrl = "info_couture",
                CountryId = 1,
                PrimaryPersonName = "primary person",
                PrimaryPersonEmailId = "primary@gmail.com",
                PrimaryPersonContactNo = "458545555",
                PrimaryPersonSkypeId = "primaryskype",
                SecondaryPersonName = "secondary person",
                SecondaryPersonEmailId = "secondary@gmail.com",
                SecondaryPersonContactNo = "895476255",
                SecondaryPersonSkypeId = "seconadryskype"

            };
            ArrayList paramList = new ArrayList();
            paramList.Add(JsonConvert.SerializeObject(companyInfoDto));
            var result = companyInfoImplObj.AddCompanyInfoExcel(paramList);
            Assert.IsTrue(result > 0, "Add successfully");
        }

        [TestMethod]
        public void GetCompanyInfoById()
        {
            CompanyInfo companyInfo = new CompanyInfo {

                CompanyId=3
            };
            var result = companyInfoImplObj.GetCompanyInfoById(companyInfo.CompanyId);
            Assert.IsTrue(result!=null, "get record");
        }
        [TestMethod]
        public void UpdateCompanyInfo()
        {
            CompanyInfoDto companyInfoDto = new CompanyInfoDto
            {
                CompanyId=5,
                CompanyName = "SpeedTech.com",
                CompanyWebsite = "abc.com1",
                Status = Status.IsLead,
                CreateOn = System.DateTime.Now,
                DeadReason = "Dead reason",
                SourceName ="Client referral",
                CompanyAddress = "noida 62 near ignu",
                CompanyContactNo = "875496545",
                PostalCode = "452666",
                FaxNo = 455555,
                CompanyEmailId = "info@infocouture.com",
                SuccessScore = 1,
                LinkedInUrl = "info5linkedlin",
                CountryId = 1,
                PrimaryPersonName = "primary person",
                PrimaryPersonEmailId = "primary@gmail.com",
                PrimaryPersonContactNo = "458545555",
                PrimaryPersonSkypeId = "myprimaryskype",
                SecondaryPersonName = "secondary person",
                SecondaryPersonEmailId = "secondary@gmail.com",
                SecondaryPersonContactNo = "895476255",
                SecondaryPersonSkypeId = "seconadryskype"

            };
            var result = companyInfoImplObj.UpdateCompanyInfo(companyInfoDto);
            Assert.IsTrue(result > 0, "get record");
        }


        [TestMethod]
        public void DeleteCompanyInfo()
        {
            CompanyInfo companyInfo = new CompanyInfo
            {
                CompanyId = 1,              
            };
            var result = companyInfoImplObj.DeleteCompanyInfo(companyInfo.CompanyId);
            Assert.IsTrue(result > 0, "get record");
        }
    }
}
