namespace Mooc.Tearcher.Capture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CaptureFactory
    {
        public static CaptureBase Create(CaptureType type)
        {
            if (type == CaptureType.Audio)
            {
                throw new Exception("");
            }
            switch (type)
            {
                case CaptureType.Desktop:
                    {
                        return new DesktopCapturer();
                    }
                case CaptureType.Camera:
                    {
                        return new CameraCapturer();
                    }
            }
            return null;
        }
    }


}
