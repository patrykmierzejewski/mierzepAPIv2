using AutoMapper;
using MierzepAPIv2.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.UnitTest.Mapping
{
    public class MappingTestFixture
    {
        public MappingTestFixture()
        {
            //wskazanie mapping provile
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = ConfigurationProvider.CreateMapper();
        }

        //Dwa elemety w przypadku automappera
        public IConfigurationProvider ConfigurationProvider { get; set; } //Dołaczenie konfiguracji
        public IMapper Mapper { get; set; } //Wywoływanie metody
    }
}
