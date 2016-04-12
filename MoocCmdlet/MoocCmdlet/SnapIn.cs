using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.ComponentModel;

namespace MoocCmdlet
{
    [RunInstaller(true)]
    public class SnapIn : PSSnapIn
    {
        public override string Description
        {
            get { return "这是Mooc的PowersShell命令接口，基于它你可以实现你的高度定制的页面."; }
        }

        public override string Name
        {
            get { return "Mooc.PowerShell"; }
        }

        public override string Vendor
        {
            get { return "Mooc1.0"; }
        }
    }
}
