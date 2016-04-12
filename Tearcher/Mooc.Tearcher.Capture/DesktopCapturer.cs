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

            //this.mAviWriter = new AVIWriter();
            ////ps:avi中所有图像皆不能小于width及height
            //this.mBitmap = this.mAviWriter.Create(Path.Combine(TearcherJobConfig.CacheDir, String.Format("{0}.avi", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"))), 1, 700, 700);
        }

        public override void Capture<T>(T data)
        {
            try
            {
                transmission.Send("127.0.0.1:8899", data as Bitmap);
                
                //Bitmap image = data as Bitmap;
                //image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                ////获得指定目录下文件列表的list
                //this.mAviWriter.LoadFrame(image);
                //this.mAviWriter.AddFrame();
            }
            catch (Exception e)
            {
                File.AppendAllText("log.txt", e.Message + "\n");
            }
        }

    }
}