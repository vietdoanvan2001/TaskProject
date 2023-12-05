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
        public ServiceResult GetTaskByProjectID(int projectID, Guid userID);

        public ServiceResult UpdateByID(Tasks data);

        public ServiceResult UpdateProcess(UpdateTaskProcessParam param);
        public ServiceResult UpdateKanban(UpdateTaskProcessParam param);

        public ServiceResult GetUserTask(GetUserTaskParam param);

        public ServiceResult GetTaskByType(int projectID, Guid userID);

        //public ServiceResult GetUsersAmountTask(int projectID);
        public ServiceResult GetUsersAmountTask(int projectID, Guid userID);
    }
}
