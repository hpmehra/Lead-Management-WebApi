using IC.LMS.WebApi.App_Start;
using IC.LMS.WebApi.Constant;
using IC.LMS.WebApi.Models;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace IC.LMS.WebApi.Controllers
{
    [HandleAndLogErrorAttribute(Status = HttpStatusCode.BadRequest)]
    public class BaseController : ApiController
    {
        protected Claims claims { get; set; }
        public BaseController()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            Claims _claims = new Claims
            {
                userName = identity.Claims.Where(c => c.Type == Constants.userName)
                               .Select(c => c.Value).SingleOrDefault(),
                userID=int.Parse( identity.Claims.Where(c => c.Type == Constants.userID)
                               .Select(c => c.Value).SingleOrDefault())
            };
            claims = _claims;
        }
         
    }
}
