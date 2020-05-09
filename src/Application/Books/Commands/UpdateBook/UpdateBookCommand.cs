using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<int>
	{

	}
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        public Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
