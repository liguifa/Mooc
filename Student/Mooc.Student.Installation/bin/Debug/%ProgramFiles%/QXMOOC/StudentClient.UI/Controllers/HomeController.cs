using StudentClient.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentClient.Models;
using StudentClient.ViewModels;

namespace StudentClient.UI.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.index = new Course().GetCourseByIndex();
            return View();
        }

    }
}
