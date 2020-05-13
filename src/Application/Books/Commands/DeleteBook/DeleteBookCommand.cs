using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<int>
	{

	}
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
    {
        public Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
