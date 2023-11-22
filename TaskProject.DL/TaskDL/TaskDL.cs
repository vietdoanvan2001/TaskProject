using Dapper;
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
    public class TaskDL : BaseDL<Tasks>, ITaskDL
    {
        public ServiceResult getKanbanByProjectID(int id)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Task_GetByProjectID";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_ProjectID", id);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                var record = dbConnection.Query(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

                dbConnection.Close();

                if (record != null)
                {
                    return new ServiceResult(true, record);
                }
                else
                {
                    return new ServiceResult(false, Resource.Wrong_Account);
                }
            }
            catch (Exception)
            {

                return new ServiceResult(false, Resource.ServiceResult_Exception);
            }
        }

        public ServiceResult UpdateByID(Tasks data)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Tasks_Update";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_TaskName", data.TaskName);
            paprameters.Add($"v_StartDate", data.StartDate);
            paprameters.Add($"v_EndDate", data.EndDate);
            paprameters.Add($"v_AssigneeID", data.AssigneeID);
            paprameters.Add($"v_AssigneeName", data.AssigneeName);
            paprameters.Add($"v_AssigneeEmail", data.AssigneeEmail);
            paprameters.Add($"v_ProjectID", data.ProjectID);
            paprameters.Add($"v_KanbanID", data.KanbanID);
            paprameters.Add($"v_Process", data.Process);
            paprameters.Add($"v_Description", data.Description);
            paprameters.Add($"v_FinishDate", data.FinishDate);
            paprameters.Add($"v_TaskID", data.TaskID);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                var record = dbConnection.Query(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

                dbConnection.Close();

                if (record != null)
                {
                    return new ServiceResult(true, record);
                }
                else
                {
                    return new ServiceResult(false, Resource.Wrong_Account);
                }
            }
            catch (Exception)
            {

                return new ServiceResult(false, Resource.ServiceResult_Exception);
            }
        }

        public ServiceResult UpdateKanban(UpdateTaskProcessParam param)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Tasks_UpdateKanban";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_TaskID", param.TaskID);
            paprameters.Add($"v_KanbanID", param.Process);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                var record = dbConnection.Execute(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

                dbConnection.Close();

                if (record != null)
                {
                    return new ServiceResult(true, record);
                }
                else
                {
                    return new ServiceResult(false, Resource.Wrong_Account);
                }
            }
            catch (Exception)
            {

                return new ServiceResult(false, Resource.ServiceResult_Exception);
            }
        }

        public ServiceResult UpdateProcess(UpdateTaskProcessParam param)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Tasks_UpdateProcess";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_TaskID", param.TaskID);
            paprameters.Add($"v_Process", param.Process);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                var record = dbConnection.Execute(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

                dbConnection.Close();

                if (record != null)
                {
                    return new ServiceResult(true, record);
                }
                else
                {
                    return new ServiceResult(false, Resource.Wrong_Account);
                }
            }
            catch (Exception)
            {

                return new ServiceResult(false, Resource.ServiceResult_Exception);
            }
        }
    }
}
