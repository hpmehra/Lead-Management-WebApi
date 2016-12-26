using IC.LMS.Business.Contract;
using IC.LMS.Domain.Dto;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IC.LMS.WebApi.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly IProject projectObj;
        public ProjectController(IProject _projectObj)
        {
            projectObj = _projectObj;
        } 
        [HttpPost]
        public HttpResponseMessage AddProject(ProjectRequirementDto projectReqDto)
        {
            var response = projectObj.AddProject(projectReqDto);
            if(response>0)
            {
                var result = JObject.Parse("{ 'ProjectID' : " + response + " }");
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Record couldn’t be saved");
        }

        [HttpGet]
        public HttpResponseMessage GetProjectAll()
        {

            var data = projectObj.GetProjectAll();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No records found");
        }

        [HttpGet]
        public HttpResponseMessage GetProjectById(int projectId)
        {
            var data = projectObj.GetProjectById(projectId);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No records found ");
        }
    }
}
