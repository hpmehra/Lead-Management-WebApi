using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using System.Collections;
using System.Collections.Generic;

namespace IC.LMS.Business.Contract
{
    public interface ICompanyInfo
    {
        IEnumerable<CompanyInfo> GetCompanyInfoAll();
        int AddCompanyInfo(CompanyInfoDto companyInfoDto);
        CompanyInfo GetCompanyInfoById(int companyId);
        int UpdateCompanyInfo(CompanyInfoDto companyInfoDto);
        int DeleteCompanyInfo(int companyId);
        int AddCompanyInfoExcel(ArrayList arrList);
    }

}
