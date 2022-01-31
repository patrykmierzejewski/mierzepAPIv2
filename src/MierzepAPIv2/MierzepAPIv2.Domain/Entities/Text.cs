using MierzepAPIv2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Domain.Entities
{
    public class Text : AuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
