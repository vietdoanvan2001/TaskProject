using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Common.Entities
{
    public class Tasks: BaseAuditEntities
    {
        public int TaskID { get; set; }

        public string TaskName { get; set; }

        public int Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public Guid AssigneeID { get; set; }

        public string AssigneeName { get; set;}

        public string AssigneeEmail { get; set;}

        public int ProjectID { get; set; }

        public int KanbanID { get; set; }

        public int Process { get; set; }

        public string Description { get; set; }

        public string ProjectName { get; set; }

        public string ColumnName { get; set; }

        public string Background { get; set; }
    }
}
