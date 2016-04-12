using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Tearcher.Capture
{
    public class CameraCapturer : CaptureBase
    {
        public CameraCapturer() : base(CaptureType.Camera)
        {
        }

        public override void Capture<T>(T data)
        {
            base.BaseCaptureCall(data as Bitmap);
        }
    }
}
