using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Common.Entities
{
    public class UserFilterParam
    {
        public int Status { get; set; }

        public string Keyword { get; set; }

        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}
