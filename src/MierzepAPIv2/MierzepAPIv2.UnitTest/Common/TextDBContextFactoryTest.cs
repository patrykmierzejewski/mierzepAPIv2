using Microsoft.EntityFrameworkCore;
using MierzepAPIv2.Application.Common.Interfaces;
using MierzepAPIv2.Domain.Entities;
using MierzepAPIv2.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.UnitTest.Common
{
    public static class TextDBContextFactoryTest
    {
        public static Mock<TextDBContext> Create()
        {
            var dateTime = new DateTime(2000, 1, 1);
            var dateTimeMock = new Mock<IDateTime>();

            dateTimeMock.Setup(m => m.Now).Returns(dateTime); // konfiguracja mocka dataTime i w odpoweidzi DateTime

            //var currentUserMock = new Mock<ICurrentUser>();
            //currentUserMock.Setup(m => m.Email).Returns("user@user.pk");
            //currentUserMock.Setup(m => m.IsAuthenticated).Returns(true);

            var options = new DbContextOptionsBuilder<TextDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options; //baza danych w pamięci - randomowa nazwa aby była jakas

            var mock = new Mock<TextDBContext>(options, dateTimeMock.Object) // jezeli są nowe to dochodzą nowe obiekty
            {
                CallBase = true //Wskazany domyslny context jezelu nue ma jakiegos setupu
            };

            var context = mock.Object;

            //First if database is created and exists
            context.Database.EnsureCreated();

            context.SaveChanges();

            return mock;
        }

        public static void Destroy(TextDBContext textDBContext)
        {
            textDBContext.Database.EnsureDeleted();

            textDBContext.Dispose();
        }
    }
}
