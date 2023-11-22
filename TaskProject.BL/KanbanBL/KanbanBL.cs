using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.BL.BaseBL;
using TaskProject.BL.ProjectBL;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.DL.BaseDL;
using TaskProject.DL.KanbanDL;
using TaskProject.DL.ProjectDL;

namespace TaskProject.BL.KanbanBL
{
    public class KanbanBL : BaseBL<Kanban>, IKanbanBL
    {
        public IKanbanDL _kanbanDL;
        public IBaseDL<Kanban> _baseDL;
        public KanbanBL(IKanbanDL kanbanDL, IBaseDL<Kanban> baseDL) : base(baseDL)
        {
            _kanbanDL = kanbanDL;
            _baseDL = baseDL;
        }

        public ServiceResult getKanbanByProjectID(int projectID)
        {
            var result = _kanbanDL.getKanbanByProjectID(projectID);
            return result;
        }

        public ServiceResult UpdateByID(Kanban data)
        {
            var result = _kanbanDL.UpdateByID(data);
            return result;
        }

        public ServiceResult UpdateSortOrder(KanbanSortOrderParam param)
        {
            var result = _kanbanDL.UpdateSortOrder(param);
            return result;
        }
    }
}
