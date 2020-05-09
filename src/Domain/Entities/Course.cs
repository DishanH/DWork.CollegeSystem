using DWork.CollegeSystem.Domain.Common;
using System;

namespace DWork.CollegeSystem.Domain.Entities
{
    public class Course : AuditableEntity
    {
        public Course(Guid id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
        public Guid AuthorId { get; private set; }
        public Guid Id { get; private set; }
#nullable disable
        public string Title { get; protected set; }

        //public Author Author { get; set; }
#nullable restore
        public string? Description { get; protected set; }

        //public Guid AuthorId { get; set; }

        public void SetNewTitleOrDescription(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
