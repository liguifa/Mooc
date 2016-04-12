using Common.Logger;
using StudentClient.BLL;
using StudentClient.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentClient.BLL
{
    public class Video : BaseBLL<StudentClient.Models.Video>
    {
        private readonly static Logger mLog = Logger.GetInstance(MethodBase.GetCurrentMethod().DeclaringType);

        public VideoModel GetVideoByVideoID(Guid videoID)
        {
            try
            {
                List<StudentClient.Models.Video> videos = base.Search(d => d.Video_Id == videoID);
                if (videos != null && videos.Count > 0)
                {
                    StudentClient.Models.Video video = videos.First();
                    List<StudentClient.Models.Video> courseVideos = base.Search(d => d.Video_IsDel == false && d.Video_CourseID == video.Video_CourseID, d => d.Video_SerialNumber);
                    VideoModel videoModel = new VideoModel();
                    videoModel.VideoID = video.Video_Id;
                    videoModel.VideoList = new List<ViewModels.Video>();
                    courseVideos.ForEach(v =>
                    {
                        videoModel.VideoList.Add(new ViewModels.Video()
                        {
                            VideoID = v.Video_Id,
                            SerialNumber = v.Video_SerialNumber,
                            TearchName = v.Teacher.Teacher_Name,
                            VideoName = v.Video_Name
                        });
                    });
                    return videoModel;
                }
                return null;
            }
            catch (Exception e)
            {
                mLog.Error(e.ToString());
                throw;
            }
        }
    }
}
