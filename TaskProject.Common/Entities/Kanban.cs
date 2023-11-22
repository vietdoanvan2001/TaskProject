using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskProject.Common.Attibutes.Attibutes;

namespace TaskProject.Common.Entities
{
    public class Kanban: BaseAuditEntities
    {
        [PrimaryKey]
        [Id]
        public int KanbanId { get; set; }

        public int ProjectId { get; set; }

        public string ColumnName { get; set; }

        public string HeaderColor { get; set; }

        public bool ShowInput { get; set; }

        public int SortOrder { get; set; }
    }
}
