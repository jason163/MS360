using MS.Web.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSAspNetMvcDemo.Controllers
{
    public class HomeController : MSController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public JsonResult JsonTest()
        {
            return Json(new { Code=1,Data="123456"},JsonRequestBehavior.AllowGet);
        }
    }
}
