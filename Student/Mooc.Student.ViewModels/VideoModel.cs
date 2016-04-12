using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClient.ViewModels
{
    public class VideoModel
    {
        public Guid VideoID { get; set; }

        public string Introduction { get; set; }

        public List<Video> VideoList { get; set; }
    }

    public class Video
    {
        public Guid VideoID { get; set; }

        public int SerialNumber { get; set; }

        public string VideoName { get; set; }

        public string TearchName { get; set; }
    }
}
