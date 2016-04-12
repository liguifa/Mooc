using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClient.ViewModels
{
    public class TearcherGlobalModel
    {
        //侧边栏菜单
        public Dictionary<string, string> Menus = new Dictionary<string, string>()
        {
            {"我的信息","/Tearcher/TearcherInfo" },
            {"我的课程","/Tearcher/Course" },
            {"我要开课","/Tearcher/AddCourse" }
        };
    }
}
