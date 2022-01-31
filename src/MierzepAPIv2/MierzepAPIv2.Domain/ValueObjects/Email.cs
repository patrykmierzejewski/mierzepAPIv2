using MierzepAPIv2.Domain.Common;
using MierzepAPIv2.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string UserName { get; set; }
        public string DomainName { get; set; }

        public static Email For(string email)
        {
            var emailObj = new Email();

            try
            {
                var index = email.IndexOf("@", StringComparison.Ordinal);
                emailObj.UserName = email.Substring(0, index);
                emailObj.DomainName = email.Substring(index + 1);
            }
            catch (Exception ex)
            {
                throw new EmailExceptions(email, ex);
            }

            return emailObj;
        }
        public override string ToString() => $"{UserName}@{DomainName}";
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserName;
            yield return DomainName;
        }
    }
}
