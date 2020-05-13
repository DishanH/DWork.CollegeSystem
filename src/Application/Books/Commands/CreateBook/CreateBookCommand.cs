using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
	{

	}
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        public Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
