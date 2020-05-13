using DWork.CollegeSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Author> Authors { get; set; }

        DbSet<Course> Courses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        //     The entry provides access to change tracking information and operations for the entity.
        //     "Collection" Provides access to change tracking and loading information for a collection navigation
        //     property that associates this entity to a collection of another entities.
    }
}
