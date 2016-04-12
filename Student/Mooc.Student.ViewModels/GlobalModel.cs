using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClient.ViewModels
{
    public class GlobalModel
    {
        private string mUsername = String.Empty;

        public string Username
        {
            get { return this.mUsername; }
            set { this.mUsername = value; }
        }

        public bool IsLogin { get; set; }

        private string mSchool = "游客";

        public string School
        {
            get { return this.mSchool; }
            set { this.mSchool = value; }
        }

        private Dictionary<string, string> mMenus = new Dictionary<string, string>()
        {
            { "首页","/"},
            { "离线课程","/Course/Offline"},
            { "在线课程","/Course/Online"}
        };

        public Dictionary<string, string> Menus
        {
            get { return this.mMenus; }
            set { this.mMenus = value; }
        }
    }
}
