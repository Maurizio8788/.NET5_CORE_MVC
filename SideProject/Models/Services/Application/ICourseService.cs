using SideProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideProject.Models.Services.Application
{
    public interface ICourseService
    {
        Task<List<CourseViewModel>> GetCoursesAsync();
        Task<CourseDetailViewModel> GetCourseAsync(int id);
    }
}
