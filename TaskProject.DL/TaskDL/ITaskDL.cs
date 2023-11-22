using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.DL.BaseDL;

namespace TaskProject.DL.TaskDL
{
    public interface ITaskDL:IBaseDL<Tasks>
    {
        public ServiceResult getKanbanByProjectID(int id);

        public ServiceResult UpdateByID(Tasks data);

        public ServiceResult UpdateProcess(UpdateTaskProcessParam param);
        public ServiceResult UpdateKanban(UpdateTaskProcessParam param);
    }
}
