using AutoMapper;
using MediatR;
using MierzepAPIv2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.Application.Authors.Command.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly ITextDbContext _textDbContext;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(ITextDbContext textDbContext,
            IMapper mapper)
        {
            _textDbContext = textDbContext;
            _mapper = mapper;
        }

        public CreateAuthorCommandHandler(ITextDbContext textDbContext)
        {
            _textDbContext = textDbContext;
        }


        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            MierzepAPIv2.Domain.Entities.Author author = new MierzepAPIv2.Domain.Entities.Author()
            {
                PersonName = new Domain.ValueObjects.PersonName() { FirstName = request.FirstName, LastName = request.LastName }
            };

            await _textDbContext.Authors.AddAsync(author);

            await _textDbContext.SaveChangesAsync(cancellationToken);

            return author.Id;
        }
    }
}
