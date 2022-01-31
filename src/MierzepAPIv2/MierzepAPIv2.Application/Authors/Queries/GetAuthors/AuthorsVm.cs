using MierzepAPIv2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Application.Directors.Queries.GetAuthors
{
    public class AuthorsVm
    {
        ICollection<AuthorDTO> Authors { get; set; }
    }
}
