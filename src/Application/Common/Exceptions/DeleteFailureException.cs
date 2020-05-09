using System;
using System.Collections.Generic;
using System.Text;

namespace DWork.CollegeSystem.Application.Common.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException()
            : base()
        {
        }

        public DeleteFailureException(string message)
            : base(message)
        {
        }

        public DeleteFailureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DeleteFailureException(string name, object key, string message)
            : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}
