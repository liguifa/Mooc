using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Function
{
    public interface IIIS
    {
        void CreateWebSite(string webSiteName, string port, string schema, string physicalPath, string appPoolName);

        void CreateApplicationPool(string appPoolName, string username, string password, string framework = "v4.0");

        bool ExistWebSite(string webSiteName);

        bool ExistApplicationPool(string appPoolname);

        void DeleteWebSite(string webSiteName);

        void DeleteApplocationPool(string appPoolname);

        void UpdateWebSite();

        void UpdateApplicationPool();
    }
}
