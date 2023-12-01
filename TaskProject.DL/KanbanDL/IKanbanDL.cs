using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.DL.BaseDL;

namespace TaskProject.DL.KanbanDL
{
    public interface IKanbanDL:IBaseDL<Kanban>
    {
        public ServiceResult getKanbanByProjectID(int idProject, Guid userID);
        public ServiceResult UpdateByID(Kanban  data);

        public ServiceResult UpdateSortOrder(KanbanSortOrderParam param);
    }
}
