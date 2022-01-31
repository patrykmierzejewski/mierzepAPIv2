using Microsoft.EntityFrameworkCore;
using MierzepAPIv2.Application.Common.Interfaces;
using MierzepAPIv2.Domain.Common;
using MierzepAPIv2.Domain.Entities;
using MierzepAPIv2.Infrastructure.Services;
using MierzepAPIv2.Persistance.SeedStaticData;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.Persistance
{
    public class TextDBContext : DbContext, ITextDbContext
    {
        private readonly IDateTime _dateTime;
        public TextDBContext(DbContextOptions<TextDBContext> options, IDateTime dateTime = null) : base(options)
        {
            _dateTime = dateTime == null ? new DateTimeService() : dateTime;
        }

        //Entities
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Text> Texts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //AuditableEntity
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.InActivated = _dateTime.Now;
                        entry.Entity.InActivatedBy = string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified; // set Modified - No deleted 
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.ModifiedBy = string.Empty;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
