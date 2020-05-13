using System;
using System.Collections.Generic;
using System.Text;

namespace DWork.CollegeSystem.Application.Common.Extensions
{
    //move it to common if anyone else use this -Dishan
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset, DateTimeOffset? dateOfDeath)
        {

            var currentDate = DateTime.UtcNow;

            int age = 0;
            if (dateOfDeath != null)
                age = dateOfDeath.Value.Year - dateTimeOffset.Year;
            else
                age = currentDate.Year - dateTimeOffset.Year;

            if (currentDate < dateTimeOffset.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}
