using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBasic;
using Oraycn.MCapture;
using System.Drawing;
using Common.Logger;
using Mooc.Tearcher.TransmissionServices;

namespace Mooc.Tearcher.Capture
{
    public abstract class CaptureBase
    {
        protected AVIWriter mAviWriter;
        protected Bitmap mBitmap;
        private static object syncRoot = new object();
        protected static readonly Logger mLog = Logger.GetInstance(typeof(DesktopCapturer));
        protected Oraycn.MCapture.ICapturer mCapturer;
        protected TransmissionService transmission = new TransmissionService();
        public delegate void CaptureCall(Bitmap bmp);
        public event CaptureCall CaptureCallEvnet;

        protected void BaseCaptureCall(Bitmap bmp)
        {
            this.CaptureCallEvnet(bmp);
        }

        protected CaptureBase(CaptureType type)
        {
            switch (type)
            {
                case CaptureType.Desktop:
                    {
                        this.mCapturer = CapturerFactory.CreateDesktopCapturer(10, true);
                        ((IDesktopCapturer)this.mCapturer).ImageCaptured += Capture;
                        break;
                    }
                case CaptureType.Audio:
                    {
                        ((IMicrophoneCapturer)this.mCapturer).AudioCaptured += Capture;
                        break;
                    }
                case CaptureType.Camera:
                    {
                        this.mCapturer = CapturerFactory.CreateCameraCapturer(0, new Size(640,480), 20);
                        ((ICameraCapturer)this.mCapturer).ImageCaptured += Capture;
                        break;
                    }
            }
        }

        public void Pause()
        {

        }

        public void Start()
        {
            mLog.Info("Start desktop capturer.");
            this.mCapturer.Start();
        }

        public void Stop()
        { 
            transmission.Close("127.0.0.1:8899");
            this.mCapturer.Stop();
            
        }

        public abstract void Capture<T>(T data) where T : class;
    }

    public enum CaptureType
    {
        Desktop,
        Audio,
        Camera
    }
}
