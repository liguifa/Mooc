using Mooc.Tearcher.TransmissionContract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common.Logger;
using System.Reflection;

namespace Mooc.Tearcher.TransmissionServices
{
    public class TransmissionService
    {
        private static readonly object syncRoot = new object();
        private static readonly Logger mLoger = Logger.GetInstance(MethodBase.GetCurrentMethod().DeclaringType);

        public void Send(string address, Bitmap obj)
        {
            lock (syncRoot)
            {
                obj = this.ResizeImage(obj, new Size(100, 100));
                MemoryStream ms = new MemoryStream();
                obj.Save(ms, ImageFormat.Png);
                byte[] bitmapData = ms.ToArray();
                ms.Close();
                string data = Convert.ToBase64String(bitmapData);
                EndpointAddress endpoint = new EndpointAddress($"net.tcp://{address}");
                using (ChannelFactory<ITransmissionContract> channelFactory = new ChannelFactory<ITransmissionContract>("ITransmissionContract"))
                {
                    try
                    {
                        ITransmissionContract proxy = channelFactory.CreateChannel(endpoint);
                        proxy.SendDesktopCapturer(bitmapData);
                    }
                    catch (Exception e)
                    {
                        mLoger.Error("An error has occurred in the send vodeo data,error:{0}", e.ToString());
                    }
                }
            }
        }

        public Bitmap ResizeImage(Bitmap mg, Size newSize)
        {
            double ratio = 0d;
            double myThumbWidth = 0d;
            double myThumbHeight = 0d;
            int x = 0;
            int y = 0;

            Bitmap bp;

            if ((mg.Width / Convert.ToDouble(newSize.Width)) > (mg.Height /
            Convert.ToDouble(newSize.Height)))
                ratio = Convert.ToDouble(mg.Width) / Convert.ToDouble(newSize.Width);
            else
                ratio = Convert.ToDouble(mg.Height) / Convert.ToDouble(newSize.Height);
            myThumbHeight = Math.Ceiling(mg.Height / ratio);
            myThumbWidth = Math.Ceiling(mg.Width / ratio);

            Size thumbSize = new Size((int)newSize.Width, (int)newSize.Height);
            bp = new Bitmap(newSize.Width, newSize.Height);
            x = (newSize.Width - thumbSize.Width) / 2;
            y = (newSize.Height - thumbSize.Height);
            System.Drawing.Graphics g = Graphics.FromImage(bp);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Rectangle rect = new Rectangle(x, y, thumbSize.Width, thumbSize.Height);
            g.DrawImage(mg, rect, 0, 0, mg.Width, mg.Height, GraphicsUnit.Pixel);

            return bp;
        }
        public void Close(string address)
        {
            lock (syncRoot)
            {
                EndpointAddress endpoint = new EndpointAddress($"net.tcp://{address}");
                using (ChannelFactory<ITransmissionContract> channelFactory = new ChannelFactory<ITransmissionContract>("ITransmissionContract"))
                {
                    try
                    {
                        ITransmissionContract proxy = channelFactory.CreateChannel(endpoint);
                        proxy.Close();
                    }
                    catch (Exception e)
                    {
                        File.AppendAllText("log.txt", e.Message);
                    }
                }
            }
        }
    }

    public class IISServer
    {
        public string HostName { get; set; }

        public string Port { get; set; }
    }
}
