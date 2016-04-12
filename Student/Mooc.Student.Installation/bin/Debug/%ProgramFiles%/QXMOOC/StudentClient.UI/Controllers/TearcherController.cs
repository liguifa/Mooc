using Common.Function;
using StudentClient.BLL;
using StudentClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentClient.UI.Controllers
{
    [UserAuthorization("tea", "/User/Login")]
    public class TearcherController : BaseController
    {

        public TearcherController()
        {
            ViewBag.tearcherGlobal = new TearcherGlobalModel();
        }

        [HttpGet]
        public ActionResult Course()
        {
            ViewBag.courses = new Course().GetCourseByTearcher(Guid.Parse("d8884704-ad96-4c81-ae89-578fb6557ea0"), 1, 20);
            return View();
        }

        [HttpPost]
        public JsonResult DelTearcher(string id)
        {
            return Json(new Course().DelCourseById(id));
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCourseIn(string name, string type, string isOpen, string isOffline, string time, string imgName)
        {
            return Json(new Course().AddCourse(name, type, isOpen, isOffline, time, imgName, (StudentClient.Models.Teacher)Session["tea"]));
        }

        [HttpPost]
        public JsonResult UpdateFile()
        {
            HttpPostedFileBase file = Request.Files["img-file"];
            string filename = "~/Static/update/images/" + DateTime.Now.ToString("yyMMddhhmmss") + ".temp";
            filename = this.Server.MapPath(filename);
            file.SaveAs(filename);
            return Json(filename);
        }
    }
}