using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskProject.Common.Attibutes.Attibutes;

namespace TaskProject.Common.Entities
{
    public class Project: BaseAuditEntities
    {
        [PrimaryKey]
        [Id]
        public int ProjectId { get; set; }

        [NotEmpty]
        public string ProjectName { get; set; }

     
        public string Description { get; set; }

        [NotEmpty]
        public DateTime StartDate { get; set; }

        [NotEmpty]
        public DateTime EndDate { get; set; }

        public DateTime FinishDate { get; set; }

        public string ListAssignee { get; set; }

        public string Background { get; set; }

        public string Icon { get; set; }

    }
}
