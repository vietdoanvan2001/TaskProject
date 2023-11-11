using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskProject.Common.Attibutes.Attibutes;

namespace TaskProject.Common
{
    public abstract class BaseAuditEntities
    {
        [ModifiedPerson]
        public string? createdBy { get; set; }

        [CurrentTime]
        public DateTime? createdDate { get; set; }

        [ModifiedPerson]
        public string? modifiedBy { get; set; }

        [CurrentTime]
        public DateTime? modifiedDate { get; set;}
    }
}
