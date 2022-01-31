using MierzepAPIv2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            //dekonstruktor aby porównać w odpowiednim momencie
            yield return FirstName;
            yield return LastName;
        }
    }
}
