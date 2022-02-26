using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SideProject.Models.ViewModels
{
    public class LessonViewModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }

        public static LessonViewModel FromDataRow(DataRow dataRow)
        {
            LessonViewModel lessonView = new LessonViewModel
            {
                Title = dataRow["Title"].ToString(),
                Duration = TimeSpan.Parse(dataRow["Duration"].ToString())
            };

            return lessonView;
        }
    }
}
