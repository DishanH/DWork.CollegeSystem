using DWork.CollegeSystem.Application.Common.Interfaces;
using System;

namespace DWork.CollegeSystem.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
