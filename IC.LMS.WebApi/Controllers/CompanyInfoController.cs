using IC.LMS.Business.Contract;
using IC.LMS.Domain.Dto;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IC.LMS.WebApi.Controllers
{
    public class CompanyInfoController : BaseController
    {
        private readonly ICompanyInfo companyInfoRepo;
        public CompanyInfoController(ICompanyInfo _companyInfoRepo)
        {
            companyInfoRepo = _companyInfoRepo;
        }

        [HttpPost]
        public HttpResponseMessage SaveCompanyInfo(CompanyInfoDto companyInfoDto)
        {
            var response = companyInfoRepo.AddCompanyInfo(companyInfoDto);
            if (response > 0)
            {
                var result = JObject.Parse("{ 'CompanyID' : " + response + " }");
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Record couldn’t be save");
        }

        [HttpPost]
        public HttpResponseMessage PostCompany(ArrayList arrList)
        {
            var response = companyInfoRepo.AddCompanyInfoExcel(arrList);

            if (response > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Records save successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Record couldn’t be save");
        }


        //  [Authorize]
        [HttpGet]
        public HttpResponseMessage GetCompanyInfoAll()
        {

            var data = companyInfoRepo.GetCompanyInfoAll();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No records found");
        }

        [HttpGet]
        public HttpResponseMessage GetCompanyInfoById(int companyId)
        {

            var data = companyInfoRepo.GetCompanyInfoById(companyId);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No records found ");
        }


        [HttpPost]
        public HttpResponseMessage UpdateCompanyInfo(CompanyInfoDto companyInfoDto)
        {
            var response = companyInfoRepo.UpdateCompanyInfo(companyInfoDto);
            if (response > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Update successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Updation failed");

        }
        [HttpPost]
        public HttpResponseMessage DeleteCompanyInfo(int companyId)
        {
            var response = companyInfoRepo.DeleteCompanyInfo(companyId);
            if (response > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Record deleted");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Record couldn’t be delete");
        }
    }
}
