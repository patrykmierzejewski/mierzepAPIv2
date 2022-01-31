using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Domain.Common
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }

        public int StatusId { get; set; }
        public string InActivatedBy { get; set; }
        public DateTime? InActivated { get; set; }
    }
}
