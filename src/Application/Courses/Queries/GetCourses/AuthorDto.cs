using AutoMapper;
using DWork.CollegeSystem.Application.Common.Mappings;
using DWork.CollegeSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Courses.Queries.GetCourses
{
    public class AuthorDto : IMapFrom<Author>
    {
        public Guid Id { get; set; }
        public List<CourseDto> Courses { get; set; }
        //public void Mapping(Profile profile)
        //{
        //    //profile.CreateMap<Author, AuthorDto>()
        //    //    .Include<Course,CourseDto>();
        //}
    }
}
