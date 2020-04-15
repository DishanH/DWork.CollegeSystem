using DWork.CollegeSystem.Application.Common.Mappings;
using DWork.CollegeSystem.Domain.Entities;

namespace DWork.CollegeSystem.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
