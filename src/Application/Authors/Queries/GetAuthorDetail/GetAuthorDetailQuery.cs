using AutoMapper;
using AutoMapper.QueryableExtensions;
using DWork.CollegeSystem.Application.Common.Exceptions;
using DWork.CollegeSystem.Application.Common.Interfaces;
using DWork.CollegeSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Authors.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery : IRequest<AuthorDetailDto>
    {
        public Guid Id { get; set; }
    }

    public class GetAuthorDetailHandler : IRequestHandler<GetAuthorDetailQuery, AuthorDetailDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDetailDto> Handle(GetAuthorDetailQuery request, CancellationToken cancellationToken)
        {
            var dto = await _context.Authors
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (dto == null)
                throw new NotFoundException(nameof(Author), request.Id);

            return _mapper.Map<AuthorDetailDto>(dto);
        }

    }
}
