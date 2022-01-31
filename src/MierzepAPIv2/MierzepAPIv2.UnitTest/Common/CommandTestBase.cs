using MierzepAPIv2.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.UnitTest.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly TextDBContext _textDbContext;
        protected readonly Mock<TextDBContext> _contextMock;

        public CommandTestBase()
        {
            _contextMock = TextDBContextFactoryTest.Create();

            _textDbContext = _contextMock.Object; //przypisanie symulacji kontekstu
        }

        /// <summary>
        /// After Fishi Test - Remove database in memory
        /// </summary>
        public void Dispose()
        {
            TextDBContextFactoryTest.Destroy(_textDbContext);
        }
    }
}
