using MediatR;
using Microsoft.EntityFrameworkCore;
using MierzepAPIv2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.Application.Authors.Command.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly ITextDbContext _textDbContext;

        public DeleteAuthorCommandHandler(ITextDbContext textDbContext)
        {
            _textDbContext = textDbContext;
        }


        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _textDbContext.Authors.FirstOrDefaultAsync(x => x.Id == request.AuthorId);
            _textDbContext.Authors.Remove(author);

            await _textDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
