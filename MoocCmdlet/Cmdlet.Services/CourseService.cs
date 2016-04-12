using Cmdlet.Contract;
using Common.CmdletMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmdlet.Services
{
    public class CourseService : ICourseContract
    {
        public CourseResponseMessage GetCourse(CourseRequestMessage request)
        {
            CourseResponseMessage response = null;

            return response;
        }
    }
}
