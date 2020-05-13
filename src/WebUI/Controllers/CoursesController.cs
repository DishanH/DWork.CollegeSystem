using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWork.CollegeSystem.Application.Courses.Commands.CreateCourse;
using DWork.CollegeSystem.Application.Courses.Queries.GetCourses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DWork.CollegeSystem.WebUI.Controllers
{
    [Route("api/authors/{authorId}/[controller]")]
    public class CoursesController : ApiController
    {
        [HttpGet()]
        public async Task<IEnumerable<CourseDto>> Get(Guid authorId)
        {
            return await Mediator.Send(new GetCoursesQuery() { AuthorId = authorId });
        }
        //[HttpGet("{authorId:GUID}", Name = nameof(Get))]
        //public async Task<ActionResult<AuthorDetailDto>> Get(Guid authorId)
        //{
        //    return await Mediator.Send(new GetAuthorDetailQuery { Id = authorId });
        //}

        [HttpPost(Name = "CreateCourseForAuthor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> CreateCourse(Guid authorId, CreateCourseCommand createCourseCommand)
        {
            if (createCourseCommand.AuthorId == Guid.Empty)
                return BadRequest();

            return await Mediator.Send(createCourseCommand);
            //return CreatedAtRoute(nameof(Get), new { authorId = result }, result);
        }
    }
}