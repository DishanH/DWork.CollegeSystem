using AutoMapper;
using AutoMapper.QueryableExtensions;
using DWork.CollegeSystem.Application.Common.Exceptions;
using DWork.CollegeSystem.Application.Common.Interfaces;
using DWork.CollegeSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Courses.Queries.GetCourses
{
    public class GetCoursesQuery : IRequest<IEnumerable<CourseDto>>
    {
        public Guid AuthorId { get; set; }
    }
    public class GetAuthorsHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors
                .FindAsync(request.AuthorId);

            if (author == null)
                throw new NotFoundException(nameof(Author), request.AuthorId);

            await _context.Entry(author)
                .Collection(i => i.Courses).LoadAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CourseDto>>(author.Courses);
        }
    }
}
