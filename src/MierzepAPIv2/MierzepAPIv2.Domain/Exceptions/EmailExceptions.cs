using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Domain.Exceptions
{
    public class EmailExceptions : Exception
    {
        public EmailExceptions(string email, Exception ex) : base($"Email \"{email}\" is invalid.", ex.InnerException)
        {

        }
    }
}
