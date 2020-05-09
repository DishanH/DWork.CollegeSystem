using DWork.CollegeSystem.Application.Common.Exceptions;
using DWork.CollegeSystem.Application.Common.Interfaces;
using DWork.CollegeSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DWork.CollegeSystem.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<Guid>
    {
        [JsonIgnore]
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateCourseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _context.Authors
                    .FindAsync(request.AuthorId);

                if (author == null)
                    throw new NotFoundException(nameof(Author), request.AuthorId);

                //await _context.Entry(author).Collection(a => a.Courses).LoadAsync();
                //author.DeleteCourse(Guid.Parse("1d9dc014-ad44-4b1d-99d8-18f8bfb8f31a"));

                //Course course = author.UpdateCourse(Guid.Parse("1d9dc014-ad44-4b1d-99d8-18f8bfb8f31a"), request.Title, request.Description);
                //_context.Entry(course).State = EntityState.Modified;                
                var course = author.AddCourse(request.Title, request.Description);
                _context.Entry(course).State = EntityState.Added;
                await _context.SaveChangesAsync(cancellationToken);
                //return course.Id;
                return course.Id;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
