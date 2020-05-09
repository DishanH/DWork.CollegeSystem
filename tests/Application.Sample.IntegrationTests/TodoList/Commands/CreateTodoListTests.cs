using DWork.CollegeSystem.Application.Common.Exceptions;
using DWork.CollegeSystem.Application.TodoLists.Commands.CreateTodoList;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sample.IntegrationTests.TodoList.Commands
{
    using static Testing;
    public class CreateTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequiredMinimumField() {

            //Arrange
            var command = new CreateTodoListCommand();
            //Act
            //Action act = () => FluentActions.Invoking(() => SendAsync(command));
            //single line without act-assert
            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>();
            //Assert
            //act.Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldRequireUniqueTitle()
        {
            await SendAsync(
                new CreateTodoListCommand
                {
                    Title = "Test Title"
                });

            var command = new CreateTodoListCommand();
            command.Title = "Test Title";

            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTodoList()
        {
            //test user(want to run it as a logged user) with fake(mock) user service
            //https://www.youtube.com/watch?v=2UJ7mAtFuio
            //var userId = await RunAsDefaultUserAsync();


            //Arange
            var command = new CreateTodoListCommand();
            command.Title = "Test Title";

            //Act
            var listId = await SendAsync(command);

            //Assert
            var list = await FindAsync<DWork.CollegeSystem.Domain.Entities.TodoList, int>(listId);

            list.Should().NotBeNull();
            list.Title.Should().Be(command.Title);
            list.Created.Should().BeCloseTo(DateTime.Now, 10000);
            //list.Created.Should().Be(userId);
        }

    }
}
