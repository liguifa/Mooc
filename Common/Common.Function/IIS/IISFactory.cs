using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Function
{
    public static class IISFactory
    {
        public static IIIS Create()
        {
            IISVersion iisVersion = GetIISVersion();
            if (iisVersion == IISVersion.IIS7)
            {
                return new IIS7();
            }
            return null;
        }

        public static IISVersion GetIISVersion()
        {
            DirectoryEntry entry = new DirectoryEntry(String.Format("IIS://{0}/W3SVC/INFO", Dns.GetHostName()));
            string majorVersion = entry.Properties["MajorIISVersionNumber"].Value.ToString();
            if (majorVersion.Equals("8"))
            {
                return IISVersion.IIS8;
            }
            else if (majorVersion.Equals("7"))
            {
                return IISVersion.IIS7;
            }
            else
            {
                return IISVersion.None;
            }
        }
    }

    public enum IISVersion
    {
        IIS7,
        IIS8,
        None
    }
}
