using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.BL.BaseBL;
using TaskProject.Common;
using TaskProject.Common.Entities;

namespace TaskProject.BL.TaskBL
{
    public interface ITaskBL:IBaseBL<Tasks>
    {
        public ServiceResult getKanbanByProjectID(int id);

        public ServiceResult UpdateByID(Tasks data);

        public ServiceResult UpdateProcess(UpdateTaskProcessParam param);

        public ServiceResult UpdateKanban(UpdateTaskProcessParam param);
    }
}
