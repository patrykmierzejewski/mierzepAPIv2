using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MierzepAPIv2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Persistance.Configurations
{
    /// <summary>
    /// Fluet API
    /// </summary>
    public class TextConfiguration : IEntityTypeConfiguration<Text>
    {
        public void Configure(EntityTypeBuilder<Text> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Content).HasMaxLength(500).IsRequired();

            builder.Property(p => p.Content).HasDefaultValue("Empty");
        }
    }
}
