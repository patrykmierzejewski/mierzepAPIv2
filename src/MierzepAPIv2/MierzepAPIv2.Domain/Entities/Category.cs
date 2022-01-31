using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Texts = new HashSet<Text>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Text> Texts { get; set; }
    }
}
