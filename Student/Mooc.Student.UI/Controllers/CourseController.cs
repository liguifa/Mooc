using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentClient.ViewModels;
using StudentClient.BLL;

namespace StudentClient.UI.Controllers
{
    public class CourseController : BaseController
    {
        [HttpGet]
        public ActionResult Online()
        {
            ViewBag.courses = new StudentClient.BLL.Course().GetCourseByOnline(1, 30);
            return View();
        }

        [HttpGet]
        public ActionResult Offline()
        {
            ViewBag.courses = new StudentClient.BLL.Course().GetCourseByOffline(1, 30);
            return View();
        }

        [HttpGet]
        public ActionResult Video(Guid videoID)
        {
            ViewBag.video = new StudentClient.BLL.Video().GetVideoByVideoID(videoID);
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SearchHint(string key)
        {
            return Json(new Course().SearchHint(key));
        }

        [HttpPost]
        public ActionResult Search(string key)
        {
            ViewBag.courses = new Course().Search(key);
            return View();
        }

        [HttpGet]
        public ActionResult GetCourseByKey(string courseType,string key)
        {
            ViewBag.courses = new Course().GetCourseByKey(courseType, key);
            return View("Search");
        }
    }
}