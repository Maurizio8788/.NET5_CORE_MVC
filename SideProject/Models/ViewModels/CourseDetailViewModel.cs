using SideProject.Models.Enums;
using SideProject.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SideProject.Models.ViewModels
{
    public class CourseDetailViewModel : CourseViewModel
    {
        public string Description { get; set; }
        public List<LessonViewModel> Lesson { get; set; }
        public TimeSpan TotalCourseDuration {
            get => TimeSpan.FromSeconds(Lesson.Sum(l => l.Duration.TotalSeconds));
        }


        public static new CourseDetailViewModel FromDataRow(DataRow courseRows)
        {
            var courseViewModel = new CourseDetailViewModel
            {
                Title = courseRows["Title"].ToString(),
                Author = courseRows["Author"].ToString(),
                Description = courseRows["Description"].ToString(),
                ImagePath = courseRows["ImagePath"].ToString(),
                Rating = Convert.ToDouble(courseRows["Rating"]),
                FullPrice = new Money
                (
                    Enum.Parse<Currency>(courseRows["FullPrice_Currency"].ToString()),
                    Convert.ToDecimal(courseRows["FullPrice_Amount"])
                ),
                CurrentPrice = new Money
                (
                    Enum.Parse<Currency>(courseRows["CurrentPrice_Currency"].ToString()),
                    Convert.ToDecimal(courseRows["CurrentPrice_Amount"])
                ),
                Id = Convert.ToInt32(courseRows["Id"]),
                Lesson = new List<LessonViewModel>()
            };

            return courseViewModel;
        }
    }
}
