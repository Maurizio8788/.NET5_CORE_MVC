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
        public IActionResult Index()
        {
            ViewData["Title"] = "Catalogo dei corsi";
            List<CourseViewModel> courses=_courseService.GetCourses();
            return View(courses);
        }

        public IActionResult Detail(int id)
        {
            CourseDetailViewModel course = _courseService.GetCourse(id);
            ViewData["Title"] = course.Title;
            return View(course);
        }
    }
}
