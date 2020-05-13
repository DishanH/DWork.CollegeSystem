using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWork.CollegeSystem.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(v => v.Description)
                .NotEmpty()
                .MaximumLength(1500);
        }
    }
}
