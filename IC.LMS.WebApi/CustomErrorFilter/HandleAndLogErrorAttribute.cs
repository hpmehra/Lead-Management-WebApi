using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace IC.LMS.WebApi.App_Start
{

    public class HandleAndLogErrorAttribute : ExceptionFilterAttribute
    {
       // public Type Type { get; set; }
        public HttpStatusCode Status { get; set; }
        public override void OnException(HttpActionExecutedContext context)
        {
            Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(context.Exception));
            var ex = "Bad Request";
            //if (ex.GetType() is Type)
            //{ 
            var response = context.Request.CreateResponse<string>(Status, ex);
            throw new HttpResponseException(response);
           // }

        }
    }
}