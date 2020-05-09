using DWork.CollegeSystem.Domain.Common;
using System.Collections.Generic;

namespace DWork.CollegeSystem.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public TodoList()
        {
            Items = new List<TodoItem>();
        }

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Colour { get; set; } = string.Empty;

        public IList<TodoItem> Items { get; set; }
    }
}
