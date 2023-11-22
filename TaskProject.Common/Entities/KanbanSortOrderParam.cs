using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Common.Entities
{
    public class KanbanSortOrderParam
    {
        public int ProjectID { get; set; }

        public int OldIndex { get; set; }

        public int NewIndex { get; set; }
    }
}
