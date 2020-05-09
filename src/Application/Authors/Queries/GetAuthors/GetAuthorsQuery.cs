using AutoMapper;
using AutoMapper.QueryableExtensions;
using DWork.CollegeSystem.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Authors.Queries.GetAuthors
{
    public class GetAuthorsQuery : IRequest<IEnumerable<AuthorDto>>
    {
        //paging
        //filtering
        //searching
    }

    public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Authors
                .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

    }
}
