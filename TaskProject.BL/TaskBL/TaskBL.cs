using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.BL.BaseBL;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.DL;
using TaskProject.DL.BaseDL;
using TaskProject.DL.TaskDL;

namespace TaskProject.BL.TaskBL
{
    public class TaskBL : BaseBL<Tasks>, ITaskBL
    {
        public ITaskDL _taskDL;
        public IBaseDL<Tasks> _baseDL;

        public TaskBL(ITaskDL taskDL,IBaseDL<Tasks> baseDL) : base(taskDL)
        {
            _taskDL = taskDL;
            _baseDL = baseDL;
        }

        public ServiceResult getKanbanByProjectID(int id)
        {
            var result = _taskDL.getKanbanByProjectID(id);
            return result;
        }

        public ServiceResult UpdateByID(Tasks data)
        {
            var result = _taskDL.UpdateByID(data);
            return result;
        }

        public ServiceResult UpdateKanban(UpdateTaskProcessParam param)
        {
            var result = _taskDL.UpdateKanban(param);
            return result;
        }

        public ServiceResult UpdateProcess(UpdateTaskProcessParam param)
        {
            var result = _taskDL.UpdateProcess(param);
            return result;
        }
    }
}
