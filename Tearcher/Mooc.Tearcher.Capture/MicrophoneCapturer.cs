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
            this.mCapturer = CapturerFactory.CreateMicrophoneCapturer(0);
        }

        public override void Capture<T>(T data)
        {
            byte[] sound = data as byte[];
        }
    }
}
