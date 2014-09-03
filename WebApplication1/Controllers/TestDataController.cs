using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestDataController : Controller
    {
        // GET: TestData
        public ActionResult Index()
        {
            return Json(new { greeting = "Hello, Json!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Send(GreetingModel model)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }

    public class GreetingModel
    {
        public string Greeting { get; set; }
    }
}