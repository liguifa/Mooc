namespace Mooc.Tearcher.Capture
{
    using Oraycn.MCapture;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class MicrophoneCapturer : CaptureBase
    {
        public MicrophoneCapturer() : base(CaptureType.Audio)
        {
           
        }

        public override void Capture<T>(T data)
        {
            byte[] sound = data as byte[];
        }
    }
}
