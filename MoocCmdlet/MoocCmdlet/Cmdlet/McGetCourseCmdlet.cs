using MoocCmdlet.BaseCmdlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Common.CmdletMessage;
using Cmdlet.ClientServices;
using MoocCmdlet.Result;
using Common.CmdletModels;
using Common.Logger;

namespace MoocCmdlet.Cmdlet
{
    [Cmdlet("Get", "McCourse")]
    public class McGetCourseCmdlet : McBaseCmdlet
    {
        [Parameter]
        public string CourseName { get; set; }

        [Parameter]
        public string CourseUri { get; set; }

        [Parameter]
        public string CourseId { get; set; }

        [Parameter]
        public string CourseTearcher { get; set; }

        [Parameter]
        public string CourseSchool { get; set; }

        protected override void ProcessRecord()
        {
            Logger.Instance(typeof(McGetCourseCmdlet)).Info("Get-McCourse -CourseName {0} -CourseId {1} -CourseUri {2} -CourseTearcher {3} -CourseSchool {4}", this.CourseName, this.CourseId, this.CourseUri, this.CourseTearcher, this.CourseSchool);
            try
            {
                //构建Request对象
                CourseRequestMessage request = new CourseRequestMessage()
                {
                    Name = this.CourseName,
                    Id = this.CourseId,
                    School = this.CourseSchool,
                    Tearcher = this.CourseTearcher,
                    Uri = this.CourseUri
                };
                //调用WCF读取数据
                CourseService courseService = new CourseService("127.0.0.1", "8850");
                CourseResponseMessage response = courseService.GetCourse(request);
                List<GetCourseResult> results = new List<GetCourseResult>();
                //构建结果对象
                foreach (Course course in response.Courses)
                {
                    GetCourseResult result = new GetCourseResult()
                    {
                        Name = course.Name,
                        Tearcher = course.Tearcher,
                        Url = course.Url
                    };
                    results.Add(result);
                }
                this.WriteObject(results);
            }
            catch (Exception e)
            {
                //this.WriteError(new ErrorRecord(e,"0001",null,null));
            }
        }
    }
}
