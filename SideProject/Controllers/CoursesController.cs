using Microsoft.AspNetCore.Mvc;
using SideProject.Models.Services.Application;
using SideProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideProject.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController( ICourseService courseService )
        {
            this._courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Catalogo dei corsi";
            List<CourseViewModel> courses = await _courseService.GetCoursesAsync();
            return View(courses);
        }

        public async Task<IActionResult> Detail(int id)
        {
            CourseDetailViewModel course = await _courseService.GetCourseAsync(id);
            ViewData["Title"] = course.Title;
            return View(course);
        }
    }
}
