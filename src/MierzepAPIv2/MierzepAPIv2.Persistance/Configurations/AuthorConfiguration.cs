using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MierzepAPIv2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Persistance.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> modelBuilder)
        {
            // this is value Object - no new entity
            modelBuilder.OwnsOne(p => p.PersonName)
                .Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(100)
                .IsRequired(); 

            modelBuilder.OwnsOne(p => p.PersonName)
                .Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(100)
                .IsRequired(); 
        }
    }
}
