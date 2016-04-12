using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentClient.UI.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public AdminController()
        {
            ViewBag.id = Guid.NewGuid().ToString();
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetStudentList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetStudentListJson()
        {
            return Json(new StudentClient.BLL.Student().GetStudentByIndex("1","20"));
        }

        //[HttpPost]
        //public JsonResult UpadteStudentInfo(string student_id)
        //{
        //    return Json(new StudentClient.BLL.Student().UpadteStudentInfo());
        //}
    }
}
