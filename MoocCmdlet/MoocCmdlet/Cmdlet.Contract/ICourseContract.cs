using Common.CmdletMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmdlet.Contract
{
    public interface ICourseContract
    {
        CourseResponseMessage GetCourse(CourseRequestMessage request);
    }
}
