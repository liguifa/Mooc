using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooc.Student.TransmissionContract;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Mooc.Student.TransmissionServices
{
    public class Transmission : ITransmissionContract
    {
        static AVIWriter mAviWriter = new AVIWriter();
        static Bitmap mBitmap = mAviWriter.Create(@"C:\Users\Guifa.Lee\Desktop\Mooc\Mooc-master\StudentClient.UI\Static\update\videos\0.avi", 1, 100, 100);
        private static int n = 0;
        private static int i = 0;
        public void SendDesktopCapturer(byte[] data)
        {
            try
            {
                //byte[] buffer = System.Convert.FromBase64String(data);
                //将图像的字节数组放入内存流               
                MemoryStream ms = new MemoryStream(data);
                //通过流对象建立Bitmap                   
                Bitmap bmp = new Bitmap(ms);
                bmp.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", $"{i}.jpg"), ImageFormat.Jpeg);
                i++;

                ////ps:avi中所有图像皆不能小于width及height

                bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                ////获得指定目录下文件列表的list
                mAviWriter.LoadFrame(bmp);
                mAviWriter.AddFrame();
                if (i == 100)
                {
                    n++;
                    this.Close();
                    mAviWriter = new AVIWriter();
                    mBitmap = mAviWriter.Create(@"C:\Users\Guifa.Lee\Desktop\Mooc\Mooc-master\StudentClient.UI\Static\update\videos\"+n+".avi", 1, 100, 100);
                    i = 0;
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("log.txt", e.ToString());
                File.AppendAllText("log.txt", "\r\n");
            }
        }

        public void Close()
        {
            mAviWriter.Close();
            mBitmap.Dispose();
        }
    }
}
