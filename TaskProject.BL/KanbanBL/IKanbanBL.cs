using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.BL.BaseBL;
using TaskProject.Common;
using TaskProject.Common.Entities;

namespace TaskProject.BL.KanbanBL
{
    public interface IKanbanBL : IBaseBL<Kanban>
    {
        public ServiceResult getKanbanByProjectID(int projectID);

        public ServiceResult UpdateByID(Kanban data);

        public ServiceResult UpdateSortOrder(KanbanSortOrderParam param);

    }
}
