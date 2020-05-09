using DWork.CollegeSystem.Domain.Common;
using DWork.CollegeSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DWork.CollegeSystem.Domain.Entities
{
    public class Author : AuditableEntity, IAggregateRoot
    {
        public Author(string firstName,
            string lastName,
            DateTimeOffset dateOfBirth,
            string mainCategory)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            MainCategory = mainCategory;
            DateOfDeath = null;
            _courses = new List<Course>();
        }
        public Author(string firstName,
            string lastName,
            DateTimeOffset dateOfBirth,
            string mainCategory,
            DateTimeOffset dateOfDeath)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            MainCategory = mainCategory;
            DateOfDeath = dateOfDeath;
            _courses = new List<Course>();
        }

        public Course AddCourse(string title, string description) =>
            AddOrUpdateCourse(Guid.Empty, title, description);

        public Course UpdateCourse(Guid id, string title, string description) =>
            AddOrUpdateCourse( id, title, description);

        public void DeleteCourse(Guid id)
        {
            var course = _courses.Find(a => a.Id == id);
            if (course == null)
                throw new AggregateChildNotFoundException(nameof(Course), id);
            _courses.Remove(course);
        }

        private Course AddOrUpdateCourse(Guid id, string title, string description)
        {
            //...
            // Domain rules/logic for adding the course to the author
            // ...example..https://github.com/dotnet-architecture/eShopOnContainers/blob/master/src/Services/Ordering/Ordering.Domain/AggregatesModel/BuyerAggregate/Buyer.cs
            //...
            Course course = null;
            if (id == Guid.Empty)
            {
                id = Guid.NewGuid();
                course = new Course(id, title, description);
                _courses.Add(course);
            }
            else
            {
                course = _courses.Find(a => a.Id == id);
                if (course == null)
                    throw new AggregateChildNotFoundException(nameof(Course), id);

                course.SetNewTitleOrDescription(title, description);
            }
            return course;
        }

        public void UpdateLastName(string lastName) => LastName = lastName;

#nullable disable
        public Guid Id { get; }

        public string FirstName { get; }

        public string LastName { get; private set; }

        public DateTimeOffset DateOfBirth { get; }

        public DateTimeOffset? DateOfDeath { get; }

        public string MainCategory { get; }
        private List<Course> _courses { get; }
#nullable restore
        public IReadOnlyCollection<Course> Courses => _courses;
    }
    // ...
    // Additional methods with domain rules/logic related to the author aggregate
    // ...
}