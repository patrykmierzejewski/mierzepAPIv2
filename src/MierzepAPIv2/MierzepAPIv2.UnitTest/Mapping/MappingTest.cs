using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MierzepAPIv2.UnitTest.Mapping
{
    public class MappingTest : IClassFixture<MappingTestFixture> // Pobierzemy onfiguracje z warstwy aplikacji
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;

        public MappingTest(MappingTestFixture mappingTestFixture)
        {
            _configurationProvider = mappingTestFixture.ConfigurationProvider;
            _mapper = mappingTestFixture.Mapper;
        }

        [Fact]
        public void ShuldHaveValidConfuguration()
        {
            _configurationProvider.AssertConfigurationIsValid();
        }
    }
}
