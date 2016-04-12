namespace Mooc.Tearcher.Capture
{
    using System;
    using System.Drawing;
    using Oraycn.MCapture;
    using System.Threading;
    using System.IO;
    using TransmissionServices;

    internal class DesktopCapturer : CaptureBase
    {
       
        public DesktopCapturer() : base(CaptureType.Desktop)
        {
        }

        public override void Capture<T>(T data)
        {
            try
            {
                transmission.Send("127.0.0.1:8899", data as Bitmap);
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the send desktop data,error:{0}", e.ToString());
            }
        }

    }
}