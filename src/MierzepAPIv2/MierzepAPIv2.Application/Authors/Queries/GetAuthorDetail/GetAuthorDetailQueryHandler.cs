using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MierzepAPIv2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.Application.Directors.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryHandler : IRequestHandler<GetAuthorDetailQuery, AuthorDetailVm>
    {
        private ITextDbContext _textDbContext;
        private readonly IMapper _mapper;

        public GetAuthorDetailQueryHandler(ITextDbContext textDbContext,
            IMapper mapper)
        {
            _textDbContext = textDbContext;
            _mapper = mapper;
        }


        public async Task<AuthorDetailVm> Handle(GetAuthorDetailQuery request, CancellationToken cancellationToken)
        {
            var author = await _textDbContext.Authors
                .Include(x => x.Texts)
                .FirstOrDefaultAsync(x => x.Id == request.AuthorId);

            var authorVM = _mapper.Map<AuthorDetailVm>(author);

            return authorVM;
        }
    }
}
