using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWork.CollegeSystem.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .NotEmpty();
            RuleFor(v => v.DateOfBirth)
                .NotEmpty();
            RuleForEach(v => v.Courses)
                .ChildRules(course =>
                {
                    course.RuleFor(c => c.Title)
                    .NotEmpty();
                });
        }
    }
}