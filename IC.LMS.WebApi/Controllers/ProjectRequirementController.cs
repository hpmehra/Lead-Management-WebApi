using IC.LMS.Business.Contract;
using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using IC.LMS.WebApi.App_Start;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System;

namespace IC.LMS.WebApi.Controllers
{
    [HandleAndLogErrorAttribute(Status = HttpStatusCode.BadRequest)]
    public class ProjectRequirementController : ApiController
    {
        private readonly IProjectRequirement projectReqObj;
        public ProjectRequirementController(IProjectRequirement _projectReqObj)
        {
            this.projectReqObj = _projectReqObj;
        }

        [HttpPost]
        public HttpResponseMessage AddProjectRequirement(ProjectRequirementDto projectReqDto)
        {
            var response = projectReqObj.AddProjectRequirement(projectReqDto);
            if (response > 0)
            {
                var result = JObject.Parse("{ 'ProjectReqID' : " + response + " }");
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Record couldn’t be saved");
        }

        [HttpGet]
        public HttpResponseMessage GetProjectRequirementAll()
        {
            var data = projectReqObj.GetProjectRequirementAll();
           
            if (data != null)
            {         
                return Request.CreateResponse(HttpStatusCode.OK, data);              
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No records found");
        }

        [HttpGet]
        public HttpResponseMessage GetProjectRequirementById(int projectReqId)
        {           
            var data = projectReqObj.GetProjectRequirementById(projectReqId);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No records found ");
        }

        [HttpGet]
        public HttpResponseMessage GetProjectReqByCompanyId(int companyId)
        {
            var data = projectReqObj.GetProjectReqByCompanyId(companyId).ToList();
            if (data.Count >0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No records found ");
        }

        [HttpPost]
        public HttpResponseMessage UpdateProjectRequirement(ProjectRequirement projectRequirement)
        {
            var response = projectReqObj.UpdateProjectRequirement(projectRequirement);
            if (response > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Update successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Updation failed");

        }
        [HttpPost]
        public HttpResponseMessage DeleteProjectRequirement(int projectReqId)
        {
            var response = projectReqObj.DeleteProjectRequirement(projectReqId);
            if (response > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Record deleted");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Record couldn’t be delete");
        }
    }
}
