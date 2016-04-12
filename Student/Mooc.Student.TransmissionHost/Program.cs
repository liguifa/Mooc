using Mooc.Student.TransmissionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Student.TransmissionHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Transmission)))
            {
                host.Open();
                Console.Read();
            }

        }
    }
}
