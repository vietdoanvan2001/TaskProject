using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Common.Entities
{
    public class UpdatePasswordParam
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public Guid Id { get; set; }

        public string UserName { get; set; }
    }
}
