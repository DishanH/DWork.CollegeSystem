using DWork.CollegeSystem.Application.TodoLists.Queries.GetTodos;
using DWork.CollegeSystem.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sample.IntegrationTests.TodoList.Queries
{
    using static Testing;
    public class GetTodosTests : TestBase
    {
        [Test]
        public async Task SouldReturnAllListAndAssociatedItems()
        {
            //Arrange
            await AddAsync(new 
                DWork.CollegeSystem.Domain.Entities.TodoList
            {
                Title = "Shopping",
                Items = {
                    new TodoItem { Title = "Fresh fruit", Done = true },
                    new TodoItem { Title = "Bread", Done = true },
                    new TodoItem { Title = "Milk", Done = true },
                    new TodoItem { Title = "Tune", Done = true },
                    new TodoItem { Title = "Pasta" }
                }
            });

            var query = new GetTodosQuery();

            //Act
            TodosVm result = await SendAsync(query);

            //Assert
            result.Should().NotBeNull();
            result.Lists.Should().HaveCount(1);
            result.Lists.First().Items.Should().HaveCount(5);
        }

        [Test]
        public void CheckDateTime() {
            //20200428-163621 (YYYYMMDD-hhmmss)
            var datetimetest = DateTime.Now.ToString("yyyyMMdd-hhmmss");

            int code = 0001;
            //if (int.TryParse(code, out int result))
            //{
            //    result = (result + 1);
            //    code = string.Empty;
            //    for (int i = result.ToString().Length; i < 4; i++)
            //        code = code + "0";
            //    code = code + result;
            //}
            code = code + 1;
            string code1 = code.ToString("D4");
            code1.Should().Be("0002");

            
            //datetimetest.Should().Contain("x");
        }
    }
}
