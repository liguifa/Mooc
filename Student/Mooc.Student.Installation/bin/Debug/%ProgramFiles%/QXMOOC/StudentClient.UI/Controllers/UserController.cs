using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentClient.BLL;
using StudentClient.ViewModels;

namespace StudentClient.UI.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginIn(string username, string password, string type)
        {
            if (type == "0")
            {
                Student student = new Student();
                LoginInModel<StudentClient.Models.Student> loginIn = student.Login(username, password);
                if (loginIn.IsLogin)
                {
                    Session["user"] = loginIn.CurrentUser;
                }
                return Json(loginIn);
            }
            else if (type == "1")
            {
                Tearcher tearcher = new Tearcher();
                LoginInModel<StudentClient.Models.Teacher> loginIn = tearcher.Login(username, password);
                if (loginIn.IsLogin)
                {
                    Session["tea"] = loginIn.CurrentUser;
                }
                return Json(loginIn);
            }
            return null;
        }
    }
}
