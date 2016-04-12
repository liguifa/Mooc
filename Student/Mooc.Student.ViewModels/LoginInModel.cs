using StudentClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace StudentClient.ViewModels
{
    public class LoginInModel<T> where T : class
    {
        public bool IsLogin { get; set; }

        [ScriptIgnore]
        public T CurrentUser { get; set; }
    }
}
