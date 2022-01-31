using AutoMapper;
using MierzepAPIv2.Application.Common.Mappings;
using MierzepAPIv2.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MierzepAPIv2.UnitTest.Common
{
    public class QuerryTestFixtures : IDisposable
    {
        public TextDBContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QuerryTestFixtures()
        {
            Context = TextDBContextFactoryTest.Create().Object; // mockowanie fabryki kontekstu

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();

            });

            Mapper = configuration.CreateMapper();
        }

        public void Dispose()
        {
            TextDBContextFactoryTest.Destroy(Context);
        }


        /// <summary>
        /// Przekazanie kolejkci dwóch klas testowyhc - w każdej kasię będzie wykonywała się tak samo jak w innej
        /// Nie możemy uruchamiąć testów aby mieszały się same w wyniku innych testów
        /// Dlatego definiujemy kolekcję aby nigdy testy nie zostały wykonane współbieżnie.
        /// </summary>
        [CollectionDefinition("QueryCollection")]
        public class QuerryCollection : ICollectionFixture<QuerryTestFixtures>
        {

        }
    }
}
