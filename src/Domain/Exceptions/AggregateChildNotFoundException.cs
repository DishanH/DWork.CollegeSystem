using System;
using System.Collections.Generic;
using System.Text;

namespace DWork.CollegeSystem.Domain.Exceptions
{
    class AggregateChildNotFoundException : Exception
    {
        public AggregateChildNotFoundException(string name, object key)
                 : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
