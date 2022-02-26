using SideProject.Models.Enums;
using SideProject.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SideProject.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public double Rating { get; set; }
        public Money FullPrice { get; set; }
        public Money CurrentPrice { get; set; }

        public static CourseViewModel FromDataRow(DataRow courseRows)
        {
            var courseViewModel = new CourseViewModel
            {
                Title = courseRows["Title"].ToString(),
                Author = courseRows["Author"].ToString(),
                ImagePath = courseRows["ImagePath"].ToString(),
                Rating = Convert.ToDouble(courseRows["Rating"]),
                FullPrice = new Money
                (
                    Enum.Parse<Currency>(  courseRows["FullPrice_Currency"].ToString() ),
                    Convert.ToDecimal(courseRows["FullPrice_Amount"])
                ),
                CurrentPrice = new Money
                (
                    Enum.Parse<Currency>(courseRows["CurrentPrice_Currency"].ToString()),
                    Convert.ToDecimal(courseRows["CurrentPrice_Amount"])
                ),
                Id = Convert.ToInt32(courseRows["Id"])
            };

            return courseViewModel;
        }
    }
}
