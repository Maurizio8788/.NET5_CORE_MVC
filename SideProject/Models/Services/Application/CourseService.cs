﻿using SideProject.Models.Enums;
using SideProject.Models.ValueTypes;
using SideProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideProject.Models.Services.Application
{
    public interface ICourseService
    {
        CourseDetailViewModel GetCourse(int id);
        List<CourseViewModel> GetCourses();
    }

    public class CourseService : ICourseService
    {
        public List<CourseViewModel> GetCourses()
        {
            List<CourseViewModel> courseList = new List<CourseViewModel>();
            Random rand = new Random();
            for (int x = 1; x <= 20; x++)
            {
                decimal price = Convert.ToDecimal(rand.NextDouble() * 10 + 10);
                CourseViewModel course = new CourseViewModel
                {
                    Id = x,
                    Title = $"Corso {x}",
                    CurrentPrice = new Money(Currency.EUR, price),
                    FullPrice = new Money(Currency.EUR, rand.NextDouble() > 0.5 ? price : price - 1),
                    Author = "Nome Cognome",
                    Rating = rand.NextDouble() * 5.0,
                    ImagePath = "data:image/png;base64,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"
                };
                courseList.Add(course);
            }

            return courseList;
        }

        public CourseDetailViewModel GetCourse(int id)
        {
            Random rand = new Random();
            decimal price = Convert.ToDecimal(rand.NextDouble() * 10 + 10);
            CourseDetailViewModel courseDetail = new CourseDetailViewModel
            {
                Id = id,
                Title = $"Corso {id}",
                CurrentPrice = new Money(Currency.EUR, price),
                FullPrice = new Money(Currency.EUR, rand.NextDouble() > 0.5 ? price : price - 1),
                Author = "Nome Cognome",
                Rating = rand.NextDouble() * 5.0,
                ImagePath = "data:image/png;base64,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",
                Description = $"Descrizione {id}",
                Lesson = new List<LessonViewModel>()
            };

            for (int i = 1; i <= 5; i++)
            {
                LessonViewModel lesson = new LessonViewModel
                {
                    Title = $"Lezione {i}",
                    Duration = TimeSpan.FromSeconds(rand.Next(40, 90))
                };
                courseDetail.Lesson.Add(lesson);
            }

            return courseDetail;
        }
    }
}