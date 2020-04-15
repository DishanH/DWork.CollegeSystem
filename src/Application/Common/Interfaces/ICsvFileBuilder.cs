using DWork.CollegeSystem.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace DWork.CollegeSystem.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
