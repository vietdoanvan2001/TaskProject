using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskProject.Common.Attibutes.Attibutes;

namespace TaskProject.Common
{
    public class Users : BaseAuditEntities
    {
        [PrimaryKey]
        [Id]
        public Guid Id { get; set; }

        [NotEmpty]
        public string FullName { get; set; }

        [NotEmpty]
        [OnlyNumber]
        [NotDuplicate]
        public string PhoneNumber { get; set; }

        [NotEmpty]
        [IsEmail]
        [NotDuplicate]
        public string Email { get; set; }

        [NotEmpty]
        [Password]
        public string Password { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }

    }
}
