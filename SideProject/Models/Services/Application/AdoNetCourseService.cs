using SideProject.Models.Services.Infrastucture;
using SideProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SideProject.Models.Services.Application
{
    public class AdoNetCourseService : ICourseService
    {
        private readonly IDatabaseAccessor _db;

        public  AdoNetCourseService( IDatabaseAccessor db )
        {
            this._db = db;
        }
        public async Task<CourseDetailViewModel> GetCourseAsync(int id)
        {
            FormattableString sql = @$"SELECT Id, 
                                    Title, 
                                    ImagePath,
                                    Description,
                                    Author, 
                                    Rating, 
                                    FullPrice_Amount, 
                                    FullPrice_Currency, 
                                    CurrentPrice_Amount, 
                                    CurrentPrice_Currency
                           FROM    COURSES
                           WHERE id={id};
                           SELECT Title, Duration FROM Lessons WHERE CourseId={id};";
            DataSet dataSet = await _db.QueryAsync(sql);
            DataTable dataTable = dataSet.Tables[0];
            if (dataTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Did not return exactly 1 row for Course {id}");
            }

            DataRow courseRow = dataTable.Rows[0];
            CourseDetailViewModel courseDetailView = CourseDetailViewModel.FromDataRow(courseRow);

            DataTable lessonsDataTable = dataSet.Tables[1];
            foreach (DataRow dataRow in lessonsDataTable.Rows)
            {
                LessonViewModel lessonViewModel = LessonViewModel.FromDataRow(dataRow);
                courseDetailView.Lesson.Add(lessonViewModel);
            }

            return courseDetailView;

        }

        public async Task<List<CourseViewModel>> GetCoursesAsync()
        {
            FormattableString query = $@"SELECT Id, 
                                    Title, 
                                    ImagePath, 
                                    Author, 
                                    Rating, 
                                    FullPrice_Amount, 
                                    FullPrice_Currency, 
                                    CurrentPrice_Amount, 
                                    CurrentPrice_Currency 
                             FROM   Courses";
            DataSet dataSet = await _db.QueryAsync(query);
            DataTable dataTable = dataSet.Tables[0];
            List<CourseViewModel> Courses = new List<CourseViewModel>();
            foreach (DataRow courseRows in dataTable.Rows)
            {
                var course = CourseViewModel.FromDataRow(courseRows);
                Courses.Add(course);
            }
            return Courses;
        }
    }

   
}
