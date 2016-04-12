using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Function
{
    public class IIS7 : IIIS
    {
        public void CreateApplicationPool(string appPoolName, string username, string password, string framework = "v4.0")
        {
            if (ExistApplicationPool(appPoolName))
            {
                throw new Exception(string.Format("Application pool named {0} already exists.", appPoolName));
            }
            //if (string.IsNullOrEmpty(username))
            //{
            //    throw new Exception(string.Format("Username specified for application pool  is empty."));
            //}
            //if (string.IsNullOrEmpty(password))
            //{
            //    throw new Exception(string.Format("Password specified for application pool  is empty."));
            //}
            ServerManager iisManager = new ServerManager();

            ApplicationPool appPool = iisManager.ApplicationPools.Add(appPoolName);

            appPool.AutoStart = true;
            appPool.ManagedPipelineMode = ManagedPipelineMode.Integrated;
            appPool.ManagedRuntimeVersion = framework;
            appPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
            //appPool.ProcessModel.UserName = username;
            //appPool.ProcessModel.Password = Decrypt(pwd);
            appPool.ProcessModel.LoadUserProfile = true;

            iisManager.CommitChanges();
        }

        public void CreateWebSite(string webSiteName, string port, string schema, string physicalPath, string appPoolName)
        {
            if (this.ExistApplicationPool(appPoolName) == false)
            {
                throw new Exception(string.Format("Application pool named {0} doesn't exist.", appPoolName));
            }
            if (this.ExistWebSite(webSiteName))
            {
                throw new Exception(string.Format("Web site named {0} already exists.", webSiteName));
            }
            ServerManager iisManager = new ServerManager();
            Site site = null;

            if (string.Compare(schema, "http", StringComparison.OrdinalIgnoreCase) == 0)
            {
                site = iisManager.Sites.Add(webSiteName, schema, string.Format("*:{0}:", port), physicalPath);
            }

            site.ServerAutoStart = true;
            site.Applications["/"].ApplicationPoolName = appPoolName;

            Configuration iisConfig = iisManager.GetApplicationHostConfiguration();
            ConfigurationSection anonymousAuthenticationSection = iisConfig.GetSection("system.webServer/security/authentication/anonymousAuthentication", webSiteName);
            anonymousAuthenticationSection["enabled"] = true;
            anonymousAuthenticationSection["userName"] = "";
            iisManager.CommitChanges();
        }

        public void DeleteApplocationPool(string appPoolName)
        {
            ServerManager iisManager = new ServerManager();
            ApplicationPool appPool = iisManager.ApplicationPools[appPoolName];
            if (appPool != null)
            {
                iisManager.ApplicationPools.Remove(appPool);
                iisManager.CommitChanges();
            }
        }

        public void DeleteWebSite(string webSiteName)
        {
            ServerManager iisManager = new ServerManager();
            Site site = iisManager.Sites[webSiteName];
            if (site != null)
            {
                iisManager.Sites.Remove(site);
                iisManager.CommitChanges();
            }
        }


        public bool ExistApplicationPool(string appPoolName)
        {
            ServerManager iisManager = new ServerManager();
            ApplicationPool appPool = iisManager.ApplicationPools[appPoolName];
            return appPool != null;
        }

        public bool ExistWebSite(string webSiteName)
        {
            ServerManager iisManager = new ServerManager();
            Site site = iisManager.Sites[webSiteName];
            return site != null;
        }

        public void UpdateApplicationPool()
        {
            throw new NotImplementedException();
        }

        public void UpdateWebSite()
        {
            throw new NotImplementedException();
        }
    }
}
