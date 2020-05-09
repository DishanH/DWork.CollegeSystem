using DWork.CollegeSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWork.CollegeSystem.Infrastructure.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.DateOfBirth)
                .IsRequired();
            builder.Property(t => t.MainCategory)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
