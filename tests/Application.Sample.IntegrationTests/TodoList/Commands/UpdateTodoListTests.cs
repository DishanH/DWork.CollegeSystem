using DWork.CollegeSystem.Application.Common.Exceptions;
using DWork.CollegeSystem.Application.TodoLists.Commands.CreateTodoList;
using DWork.CollegeSystem.Application.TodoLists.Commands.UpdateTodoList;
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
    public class UpdateTodoListTests : TestBase
    {
        [Test]
        public void ShoudRequiredValidTodoListId()
        {
            var command = new UpdateTodoListCommand
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShoudRequiredUniqueTitle()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            await SendAsync(new CreateTodoListCommand
            {
                Title = "Other List"
            });
            
            var command = new UpdateTodoListCommand
            {
                Id = listId,
                Title = "Other List"
            };

            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>()
                .Where(ex => ex.Errors.ContainsKey("Title"))
                .And.Errors["Title"].Should().Contain("The specified title is already exists.");
        }
        //[Test]
        //public async Task ShoudRequiredUniqueTitle()
        //{
        //    var listId = await SendAsync(new CreateTodoListCommand
        //    {
        //        Title = "New List"
        //    });

        //    var command = new UpdateTodoListCommand
        //    {
        //        Id = listId,
        //        Title = "Other List"
        //    };

        //    FluentActions.Invoking(() => SendAsync(command))
        //        .Should().Throw<ValidationException>();
        //}

        [Test]
        public async Task ShoudUPdateTodoList()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var command = new UpdateTodoListCommand
            {
                Id = listId,
                Title = "Update List Title"
            };

            await SendAsync(command);

            var list = await FindAsync<DWork.CollegeSystem.Domain.Entities.TodoList,int>(listId);

            list.Title.Should().Be(command.Title);
            list.LastModified.Should().NotBeNull();
            list.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}