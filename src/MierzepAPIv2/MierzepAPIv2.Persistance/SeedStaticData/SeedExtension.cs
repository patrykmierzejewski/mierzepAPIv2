using Microsoft.EntityFrameworkCore;
using MierzepAPIv2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Persistance.SeedStaticData
{
    public static class SeedExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(d =>
            {
                d.HasData(new Category()
                {
                    Id = 1,
                    Name = "Zdrowie"
                });

                d.HasData(new Category()
                {
                    Id = 2,
                    Name = "Biznes"
                });
            });
            modelBuilder.Entity<Author>(d =>
            {
                d.HasData(new Author()
                {
                    Id = 1,
                    Created = DateTime.Now,
                    StatusId = 1
                });

                //Związane z ValueObject trzeba pisać z ręki :)
                d.OwnsOne(d => d.PersonName).HasData(new { AuthorId = 1, FirstName = "Patryk", LastName = "Mierzejewski" });
            });
            modelBuilder.Entity<Text>(d =>
            {
                d.HasData(new Text()
                {
                    Id = 1,
                    AuthorId = 1,
                    CategoryId = 1,
                    Content = "Jak zdrowo się odżywiasz to będziesz dobrze się czuł!",
                    Created = DateTime.Now,
                    StatusId = 1
                });

                d.HasData(new Text()
                {
                    Id = 2,
                    AuthorId = 1,
                    CategoryId = 2,
                    Content = "Spółka wypracowała bardzo duże zyski w tym miesiącu.",
                    Created = DateTime.Now,
                    StatusId = 1
                });

                d.HasData(new Text()
                {
                    Id = 3,
                    AuthorId = 1,
                    CategoryId = 2,
                    Content = "Polska gospodarka przychamowała rozwój i odnotowuje straty.",
                    Created = DateTime.Now,
                    StatusId = 1
                });

                d.HasData(new Text()
                {
                    Id = 4,
                    AuthorId = 1,
                    CategoryId = 1,
                    Content = "Ciągle boli go głowa jakby się rozchorował.",
                    Created = DateTime.Now,
                    StatusId = 1
                });
            });
        }
    }
}
