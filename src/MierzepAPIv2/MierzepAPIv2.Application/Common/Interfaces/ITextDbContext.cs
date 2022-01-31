using Microsoft.EntityFrameworkCore;
using MierzepAPIv2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.Application.Common.Interfaces
{
    public interface ITextDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Text> Texts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
