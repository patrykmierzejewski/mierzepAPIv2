using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Application.Authors.Command.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
