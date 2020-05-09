using DWork.CollegeSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

//Fluent Api reference https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/relationships
//or https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
namespace DWork.CollegeSystem.Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey("Id", "AuthorId");
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.Description)
                .HasMaxLength(1500);

            //builder.HasOne(t => t.Author)
            //    .WithMany(t => t.Courses)
            //    .HasForeignKey(t => t.AuthorId);
        }
    }
}
