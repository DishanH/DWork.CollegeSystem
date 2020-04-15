using DWork.CollegeSystem.Application.Common.Mappings;
using DWork.CollegeSystem.Domain.Entities;
using System.Collections.Generic;

namespace DWork.CollegeSystem.Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
}
