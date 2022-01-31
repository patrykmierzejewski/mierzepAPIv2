using MierzepAPIv2.Domain.Common;
using MierzepAPIv2.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Domain.Entities
{
    public class Author : AuditableEntity
    {
        public Author()
        {
            Texts = new HashSet<Text>();
        }

        public int Id { get; set; }
        public PersonName PersonName { get; set; }

        public ICollection<Text> Texts { get; private set; }
    }
}
