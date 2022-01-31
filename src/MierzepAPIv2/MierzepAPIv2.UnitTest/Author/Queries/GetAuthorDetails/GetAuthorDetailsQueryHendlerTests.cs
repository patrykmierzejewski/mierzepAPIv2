using AutoMapper;
using MierzepAPIv2.Application.Directors.Queries.GetAuthorDetail;
using MierzepAPIv2.Application.Directors.Queries.GetAuthors;
using MierzepAPIv2.Persistance;
using MierzepAPIv2.UnitTest.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MierzepAPIv2.UnitTest.Author.Queries.GetAuthorDetails
{
    [Collection("QueryCollection")]
    public class GetAuthorDetailsQueryHandlerTests
    {
        private readonly TextDBContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailsQueryHandlerTests(QuerryTestFixtures queryTextFixtures)
        {
            _context = queryTextFixtures.Context;
            _mapper = queryTextFixtures.Mapper;
        }

        [Fact]
        public async Task CanGetAuthorDitaliHandlerById()
        {
            var handler = new GetAuthorDetailQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetAuthorDetailQuery() { AuthorId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<AuthorDetailVm>();

            result.FullName.ShouldBe("Patryk Mierzejewski");
        }
    }
}
