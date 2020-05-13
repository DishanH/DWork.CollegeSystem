using DWork.CollegeSystem.Application.Common.Interfaces;
using DWork.CollegeSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string MainCategory { get; set; }
        public IEnumerable<CourseWithAuthor> Courses { get; set; } = new List<CourseWithAuthor>();
    }

    public class CourseWithAuthor
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateAuthorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            (
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.MainCategory
            );
            //Add courses
            foreach (var course in request.Courses)
            {
                author.AddCourse(course.Title, course.Description);
            }

            _context.Authors.Add(author);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return author.Id;
        }
    }
}