using Cmdlet.Contract;
using Common.CmdletMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Cmdlet.ClientServices
{
    public class CourseService : ICourseContract
    {

        public EndpointAddress endPoint = null;

        public CourseService(string address, string port)
        {
            try
            {
                Uri uri = new Uri(string.Format("net.tcp://{0}:{1}", address, port));
                this.endPoint = new EndpointAddress(uri);
            }
            catch (UriFormatException e)
            {
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public CourseResponseMessage GetCourse(CourseRequestMessage request)
        {
            CourseResponseMessage response = null;
            try
            {
                using (ChannelFactory<ICourseContract> factory = new ChannelFactory<ICourseContract>("CourseContract"))
                {
                    ICourseContract proxy = factory.CreateChannel(this.endPoint);
                    response = proxy.GetCourse(request);
                }
            }
            catch (CommunicationException e)
            {
            }
            catch (TimeoutException e)
            {
            }
            catch (Exception e)
            {
                throw;
            }
            return response;
        }
    }
}
