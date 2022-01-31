using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Application.Authors.Command.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<Unit>
    {
        public int AuthorId { get; set; }
    }
}
