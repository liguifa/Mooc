using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Mooc.Student.TransmissionContract
{
    [ServiceContract(Namespace = "Mooc.Student.ITransmissionContract")]
    public interface ITransmissionContract
    {
        [OperationContract]
        void SendDesktopCapturer(byte[] data);
    }
}
