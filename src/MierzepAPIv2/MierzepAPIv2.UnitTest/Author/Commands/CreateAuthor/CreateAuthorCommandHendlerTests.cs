using Microsoft.EntityFrameworkCore;
using MierzepAPIv2.Application.Authors.Command.CreateAuthor;
using MierzepAPIv2.UnitTest.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MierzepAPIv2.UnitTest.Author.Commands.CreateAuthor
{
    public class CreateAuthorCommandHendlerTests : CommandTestBase
    {
        private readonly CreateAuthorCommandHandler _createAuthorCommandHandler;
        
        public CreateAuthorCommandHendlerTests()
            :base() // ctor start CommandTestBase
        {

            _createAuthorCommandHandler = new CreateAuthorCommandHandler(_textDbContext);
        }

        [Fact]
        public async Task Handle_GiveValidRequest_ShouldInsertAuthor()
        {
            var command = new CreateAuthorCommand()
            {
                FirstName = "TTTT",
                LastName = "LLLL"
            };

            var resoult = await _createAuthorCommandHandler.Handle(command, CancellationToken.None);

            var dir = await _textDbContext.Authors.FirstAsync(x => x.Id == resoult, CancellationToken.None);

            dir.ShouldNotBeNull();
        }

    }
}
