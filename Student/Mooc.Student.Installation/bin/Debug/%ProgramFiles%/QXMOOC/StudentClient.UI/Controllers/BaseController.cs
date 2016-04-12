using StudentClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentClient.UI.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            GlobalModel global = new GlobalModel();
            if (System.Web.HttpContext.Current.Session != null && (System.Web.HttpContext.Current.Session["user"] != null || System.Web.HttpContext.Current.Session["tea"] != null))
            {
                global.IsLogin = true;
                if (System.Web.HttpContext.Current.Session["user"] != null)
                {
                    global.Username = ((StudentClient.Models.Student)System.Web.HttpContext.Current.Session["user"]).Student_Name;
                }
                else if (System.Web.HttpContext.Current.Session["tea"] != null)
                {
                    global.Username = ((StudentClient.Models.Teacher)System.Web.HttpContext.Current.Session["tea"]).Teacher_Name;
                }
            }
            ViewBag.global = global;
        }
    }
}