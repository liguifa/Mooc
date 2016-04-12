using Common.Logger;
using StudentClient.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudentClient.BLL
{
    public class Course : BaseBLL<StudentClient.Models.Cours>
    {
        private static readonly Logger mLog = Logger.GetInstance(MethodBase.GetCurrentMethod().DeclaringType);

        public IndexModel GetCourseByIndex()
        {
            try
            {
                IndexModel index = new IndexModel();
                index.InformationScience = base.Search(d => d.Course_IsDel == false && d.Course_Major == "InformationScience", d => d.Course_Time, 1, 20);
                index.LanguageHistory = base.Search(d => d.Course_IsDel == false && d.Course_Major == "LanguageHistory", d => d.Course_Time, 1, 20);
                index.LifeSciences = base.Search(d => d.Course_IsDel == false && d.Course_Major == "LifeSciences", d => d.Course_Time, 1, 20);
                index.ArtDesign = base.Search(d => d.Course_IsDel == false && d.Course_Major == "ArtDesign", d => d.Course_Time, 1, 20);
                return index;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the get course by index,error:{0}", e.ToString());
                throw;
            }

        }

        public SearchModel GetCourseByKey(string type, string key)
        {
            try
            {
                mLog.Info("Start get course,type:[{0}],key:[{1}]", type, key);
                SearchModel search = new SearchModel();
                List<StudentClient.Models.Cours> courses = base.Search(d => d.Course_Major.Equals(type) && (d.Course_Name.Contains(key) || key.Equals("all")) && !d.Course_IsDel);
                search.Courses = courses;
                mLog.Info("Course count:[{0}]", courses.Count.ToString());
                return search;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the get course by key,error:{0}", e.ToString());
                throw;
            }
        }

        public OfflineModel GetCourseByOffline(int pageIndex, int pageSize)
        {
            try
            {
                List<StudentClient.Models.Cours> videos = base.Search(d => !d.Course_IsDel && d.Course_IsOffline, d => d.Course_Time, pageIndex, pageSize);
                OfflineModel offline = new OfflineModel();
                offline.Videos = videos;
                return offline;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the get course by offline,error:{0}", e.ToString());
                throw;
            }
        }

        public OnlineModel GetCourseByOnline(int pageIndex, int pageSize)
        {
            try
            {
                List<StudentClient.Models.Cours> videos = base.Search(d => !d.Course_IsDel && !d.Course_IsOffline, d => d.Course_Time, pageIndex, pageSize);
                OnlineModel online = new OnlineModel();
                online.Courses = videos;
                return online;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the get course by online,error:{0}", e.ToString());
                throw;
            }
        }

        public TearcherCourseModel GetCourseByTearcher(Guid id, int pageIndex, int pageSize)
        {
            try
            {
                TearcherCourseModel courseModel = new TearcherCourseModel();
                List<StudentClient.Models.Cours> courses = base.Search(d => d.Course_Teacher == id && !d.Course_IsDel, d => d.Course_Time, pageIndex, pageSize).ToList();
                courseModel.Courses = courses;
                return courseModel;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the get course by tearcher,error:{0}", e.ToString());
                throw;
            }
        }

        public TearcherDelCourseModel DelCourseById(string id)
        {
            try
            {
                TearcherDelCourseModel delCourse = new TearcherDelCourseModel();
                Guid guid = Guid.Parse(id);
                if (base.SearchCount(d => d.Course_Id == guid && !d.Course_IsDel) > 0)
                {
                    StudentClient.Models.Cours course = base.Search(d => d.Course_Id == guid && !d.Course_IsDel).First();
                    course.Course_IsDel = true;
                    base.Modify(course, "Course_IsDel");
                    delCourse.IsDel = true;
                    delCourse.Id = id;
                    return delCourse;
                }
                delCourse.IsDel = false;
                delCourse.Id = id;
                return delCourse;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the remove course by id,error:{0}", e.ToString());
                throw;
            }
        }

        public TearcherAddCourseInModel AddCourse(string name, string type, string isOpen, string isOffline, string time, string imgName, StudentClient.Models.Teacher tearcher)
        {
            try
            {
                StudentClient.Models.Cours course = new Models.Cours();
                course.Course_Id = Guid.NewGuid();
                course.Course_IsDel = false;
                course.Course_IsOffline = bool.Parse(isOffline);
                course.Course_IsOpen = bool.Parse(isOpen);
                course.Course_Major = type;
                course.Course_Name = name;
                course.Course_Password = "123456";
                course.Course_College = tearcher.School.School_Name;
                course.Course_IsGeneral = false;
                course.Course_Week = time.Split(' ')[0];
                course.Course_DayOfWeek = time.Split(' ')[1];
                course.Course_Time = new TimeSpan(1, 1, 1);
                course.Course_Teacher = tearcher.Teacher_Id;
                base.Add(course);
                File.Move(imgName, Path.Combine(Path.GetDirectoryName(imgName), String.Format("{0}.png", course.Course_Id)));
                TearcherAddCourseInModel addCourse = new TearcherAddCourseInModel();
                addCourse.IsAdd = true;
                addCourse.Id = course.Course_Id.ToString();
                return addCourse;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the add course,error:{0}", e.ToString());
                throw;
            }
        }

        public SearchHintModel SearchHint(string key)
        {
            try
            {
                SearchHintModel searchHint = new SearchHintModel();
                if (base.SearchCount(d => d.Course_Name.Contains(key) && !d.Course_IsDel) > 0)
                {
                    List<StudentClient.Models.Cours> courses = base.Search(d => d.Course_Name.Contains(key) && !d.Course_IsDel, d => d.Course_Name, 1, 10).ToList();
                    foreach (StudentClient.Models.Cours course in courses)
                    {
                        searchHint.Keys += course.Course_Name + ",";
                    }
                    searchHint.Keys = searchHint.Keys.Substring(0, searchHint.Keys.Length - 1);
                }
                return searchHint;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the search course key,error:{0}", e.ToString());
                throw;
            }
        }

        public SearchModel Search(string key)
        {
            try
            {
                SearchModel search = new SearchModel();
                if (base.SearchCount(d => d.Course_Name.Contains(key) && !d.Course_IsDel) > 0)
                {
                    List<StudentClient.Models.Cours> courses = base.Search(d => d.Course_Name.Contains(key) && !d.Course_IsDel, d => d.Course_Name, 1, 10).ToList();
                    search.Courses = courses;
                }
                return search;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the search course by key,error:{0}", e.ToString());
                throw;
            }
        }
    }
}
