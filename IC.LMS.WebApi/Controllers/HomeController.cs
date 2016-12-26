using Elmah;
using IC.LMS.WebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IC.LMS.WebApi.Controllers
{
    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            //try
            //{
            //    throw new InvalidOperationException();
            //    ViewBag.Title = "Home Page";

            //}
            //catch (Exception e)
            //{

            //    ErrorSignal.FromCurrentContext().Raise(e);
            //}
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
