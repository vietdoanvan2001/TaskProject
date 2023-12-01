using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Common.Entities
{
    public class GetUserTaskParam
    {
        public Guid UserID { get; set; }

        public int ProjectID { get; set; }
    }
}
