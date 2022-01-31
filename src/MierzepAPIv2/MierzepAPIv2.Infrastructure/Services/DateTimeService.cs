using MierzepAPIv2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Infrastructure.Services
{
    /// <summary>
    /// Set One place for DateTime; (dateTime now, uniwersalTime)
    /// </summary>
    public class DateTimeService : IDateTime
    {
        /// <summary>
        /// Set DateTime - 1 Declare for system
        /// </summary>
        public DateTime Now => DateTime.Now;
    }
}
