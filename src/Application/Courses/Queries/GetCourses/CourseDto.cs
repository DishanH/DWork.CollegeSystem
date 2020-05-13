using AutoMapper;
using DWork.CollegeSystem.Application.Common.Mappings;
using DWork.CollegeSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWork.CollegeSystem.Application.Courses.Queries.GetCourses
{
    public class CourseDto : IMapFrom<Course>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public Guid AuthorId { get; set; }
    }
}
