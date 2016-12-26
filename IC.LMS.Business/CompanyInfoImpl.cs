using IC.LMS.Business.Contract;
using IC.LMS.Data.Tier.Repository;
using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using System.Collections.Generic;
using Omu.ValueInjecter;
using System;
using System.Linq;
using IC.LMS.Business.FileCabinetCS;
using System.Collections;
using Newtonsoft.Json;

namespace IC.LMS.Business
{
    public class CompanyInfoImpl : ICompanyInfo
    {

        private readonly CompanyInfoRepository companyInfoRepo;
        private readonly CompanyContactInfoRepository companyContactObj;
        private readonly CompanyPersonContactRepository companyPersonContactObj;
     
        public CompanyInfoImpl()
        {
            companyInfoRepo = new CompanyInfoRepository();
            companyContactObj = new CompanyContactInfoRepository();
            companyPersonContactObj = new CompanyPersonContactRepository();
          
        }
        public IEnumerable<CompanyInfo> GetCompanyInfoAll()
        {
          
            return companyInfoRepo.GetAll();

        }

        public int AddCompanyInfo(CompanyInfoDto companyInfoDto)
        {
            if (companyInfoDto != null)
            {
                companyInfoDto.CreateOn = DateTime.Now;
                var companyInfo = Mapper.Map<CompanyInfo>(companyInfoDto);                       
                var companyId = companyInfoRepo.Add(companyInfo).CompanyId;
                if (companyId > 0)
                {
                     CompanyContactInfo companyContact = new CompanyContactInfo
                    {
                        CompanyAddress = companyInfoDto.CompanyAddress,
                        CompanyId = companyId,
                        ContactNo = companyInfoDto.CompanyContactNo,
                        EmailId = companyInfoDto.CompanyEmailId,
                        FaxNo = companyInfoDto.FaxNo,
                        PostalCode = companyInfoDto.PostalCode,
                        LinkedInUrl = companyInfoDto.LinkedInUrl,
                        CountryId = companyInfoDto.CountryId
                    };
                    companyContactObj.Add(companyContact);


                    // primary person contact
                    CompanyPersonContact primaryPersonContact = new CompanyPersonContact
                    {
                        CompanyId = companyId,
                        PersonName = companyInfoDto.PrimaryPersonName,
                        EmailId = companyInfoDto.PrimaryPersonEmailId,
                        SkypeId = companyInfoDto.PrimaryPersonSkypeId,
                        ContactNo = companyInfoDto.PrimaryPersonContactNo,
                        Gender = companyInfoDto.Gender,
                        IsPrimary = true
                    };
                    companyPersonContactObj.Add(primaryPersonContact);
                    // secondary person contact
                    CompanyPersonContact secondaryPersonContact = new CompanyPersonContact
                    {
                        CompanyId = companyId,
                        PersonName = companyInfoDto.SecondaryPersonName,
                        EmailId = companyInfoDto.SecondaryPersonEmailId,
                        SkypeId = companyInfoDto.SecondaryPersonSkypeId,
                        ContactNo = companyInfoDto.SecondaryPersonContactNo,
                        Gender = companyInfoDto.Gender,
                        IsPrimary = false
                    };
                    companyPersonContactObj.Add(secondaryPersonContact);
                }
                return companyId;

            }
            else
            {
                return 0;
            }
        }

        public int AddCompanyInfoExcel(ArrayList arrList)
        {
            if (arrList.Count > 0)
            {
                for (int i=0; i<arrList.Count;i++)
                {
                    CompanyInfoDto companyInfoDto = JsonConvert.DeserializeObject<CompanyInfoDto>(arrList[i].ToString());
                    AddCompanyInfo(companyInfoDto);
                }
                return 1;
            }
            return 0;
        }

        public CompanyInfo GetCompanyInfoById(int companyId)
        {       
            return companyInfoRepo.GetById(companyId);
        }

        public int UpdateCompanyInfo(CompanyInfoDto companyInfoDto)
        {
            if(companyInfoDto!=null)
            {
                var companyInfo = Mapper.Map<CompanyInfo>(companyInfoDto);
              
                 companyInfoRepo.Update(companyInfo);
                CompanyContactInfo companyContact = new CompanyContactInfo
                {
                    CompanyContactId=companyInfoDto.CompanyContactId,
                    CompanyAddress = companyInfoDto.CompanyAddress,
                    CompanyId = companyInfoDto.CompanyId,
                    ContactNo = companyInfoDto.CompanyContactNo,
                    EmailId = companyInfoDto.CompanyEmailId,
                    FaxNo = companyInfoDto.FaxNo,
                    PostalCode = companyInfoDto.PostalCode,
                    LinkedInUrl = companyInfoDto.LinkedInUrl,
                    CountryId = companyInfoDto.CountryId
                };
                companyContactObj.Update(companyContact);
                return 1;
            }
            else
            {
                return 0;
            }
           
        }

        public int DeleteCompanyInfo(int companyId)
        {
            CompanyInfo result = companyInfoRepo.GetById(companyId);
            return companyInfoRepo.Delete(result);
        }

    }
}
