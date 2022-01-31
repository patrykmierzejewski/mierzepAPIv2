using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Application.Directors.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery : IRequest<AuthorDetailVm>
    {
        public int AuthorId { get; set; }
    }
}
