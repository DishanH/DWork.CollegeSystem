using DWork.CollegeSystem.Application.Authors.Commands.CreateAuthor;
using DWork.CollegeSystem.Application.Common.Exceptions;
using DWork.CollegeSystem.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sample.IntegrationTests.Authors.Commands
{
    using static Testing;
    public class CreateAuthorTest : TestBase
    {
        [Test]
        public void ShoudRequiredValidField()
        {
            //Arrange
            var command = new CreateAuthorCommand();
            //Act

            //Assert
            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>();
        }        
        [Test]
        public async Task ShoudCreateAuthor()
        {
            //Arrange
            var command = new CreateAuthorCommand();
            command.DateOfBirth = new DateTimeOffset(1900, 11, 01, 0, 0, 0, TimeSpan.Zero);
            command.FirstName = "Shan";
            command.LastName = "Senevi";
            command.MainCategory = "Science";

            //Act
            var authorId = await SendAsync(command);

            //Assert
            var author = await FindAsync<Author, Guid>(authorId);
            author.Should().NotBeNull();
            author.FirstName.Should().Be(command.FirstName);
            author.Created.Should().BeCloseTo(DateTime.Now, 10000);
        }

        [Test]
        public void ShoudRequiredValidFieldsForCourse()
        {
            //Arrange
            var command = new CreateAuthorCommand();
            command.DateOfBirth = new DateTimeOffset(1900, 11, 01, 0, 0, 0, TimeSpan.Zero);
            command.FirstName = "Shan";
            command.LastName = "Senevi";
            command.MainCategory = "Science";
            var courses = new List<CourseWithAuthor>();
            courses.Add(new CourseWithAuthor
            { Description = "Maths for life" });//no title
            command.Courses = courses;
            //Act

            //Assert
            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShoudCreateAuthorWithTwoCourses()
        {
            //Arrange
            var command = new CreateAuthorCommand();
            command.DateOfBirth = new DateTimeOffset(1900, 11, 01, 0, 0, 0, TimeSpan.Zero);
            command.FirstName = "Shan";
            command.LastName = "Senevi";
            command.MainCategory = "Science";

            var courses = new List<CourseWithAuthor>();
            courses.Add(new CourseWithAuthor
            { Title = "Maths", Description = "Maths for life" });
            courses.Add(new CourseWithAuthor
            { Title = "Sciene", Description = "Science for life" });

            command.Courses = courses;

            //Act
            var authorId = await SendAsync(command);

            //Assert
            var author = await FindAsync<Author, Guid>(authorId, "Courses");

            author.Should().NotBeNull();
            author.FirstName.Should().Be(command.FirstName);
            author.Courses.Count.Should().Be(2);
            author.Created.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
