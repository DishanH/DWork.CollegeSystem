using DWork.CollegeSystem.Domain.Common;
using DWork.CollegeSystem.Domain.Enums;
using System;

namespace DWork.CollegeSystem.Domain.Entities
{
    public class TodoItem : AuditableEntity
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public PriorityLevel Priority { get; set; }

#nullable disable
        public TodoList List { get; set; }
#nullable restore
    }
}
