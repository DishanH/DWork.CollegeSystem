using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWork.CollegeSystem.Application.Authors.Commands.CreateAuthor;
using DWork.CollegeSystem.Application.Authors.Queries.GetAuthorDetail;
using DWork.CollegeSystem.Application.Authors.Queries.GetAuthors;
using DWork.CollegeSystem.Application.Courses.Commands.CreateCourse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DWork.CollegeSystem.WebUI.Controllers
{

    public class AuthorsController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<AuthorDto>> Get()
        {
            return await Mediator.Send(new GetAuthorsQuery());
        }
        [HttpGet("{authorId:GUID}", Name = nameof(Get))]
        public async Task<ActionResult<AuthorDetailDto>> Get(Guid authorId)
        {
            return await Mediator.Send(new GetAuthorDetailQuery { Id = authorId });
        }

        [HttpPost(Name = "CreateAuthor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AuthorDetailDto>> CreateAuthor(CreateAuthorCommand createAuthorCommand)
        {
            var result = await Mediator.Send(createAuthorCommand);
            //if (result != Guid.Empty)
            //    foreach (var authorCouse in createAuthorCommand.Courses)
            //    {
            //        await Mediator.Send(new CreateCourseCommand()
            //        {
            //            AuthorId = result,
            //            Description = authorCouse.Description,
            //            Title = authorCouse.Title
            //        });
            //    }
            return CreatedAtRoute(nameof(Get), new { authorId = result }, result);
        }
    }
}