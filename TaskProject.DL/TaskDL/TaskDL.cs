using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.DL.BaseDL;
using TaskProject.DL.ProjectDL;

namespace TaskProject.DL.TaskDL
{
    public class TaskDL : BaseDL<Tasks>, ITaskDL
    {
        public ServiceResult GetTaskByProjectID(int projectID, Guid userID)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Task_GetByProjectID";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_ProjectID", projectID);
            paprameters.Add($"v_UserID", userID);

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

        public ServiceResult GetTaskByType(int id)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Tasks_GetType";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_ProjectID", id);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                var record = dbConnection.QueryMultiple(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);


                if (record != null)
                {
                    var OOD = record.Read<Tasks>().ToList();
                    var TD = record.Read<Tasks>().ToList();
                    var DS = record.Read<Tasks>().ToList();
                    var NP = record.Read<Tasks>().ToList();
                    var DN = record.Read<Tasks>().ToList();
                    var NA = record.Read<Tasks>().ToList();

                    var temp = new Dictionary<string, object>
                    {
                        {"OutOfDate",OOD },
                        {"ToDay",TD },
                        {"DueSoon",DS},
                        {"NoProblem",NP},
                        {"Done",DN},
                        {"NoneAssignee",NA}
                    };
                    return new ServiceResult(true, temp);
                }
                else
                {
                    return new ServiceResult(false, Resource.Wrong_Account);
                }
                dbConnection.Close();

            }
            catch (Exception)
            {

                return new ServiceResult(false, Resource.ServiceResult_Exception);
            }
        }

        public ServiceResult GetUsersTask(int projectID)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Tasks_GetAmountByUser";

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_ProjectID", projectID);

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

        public ServiceResult GetUserTask(GetUserTaskParam param)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Tasks_GetUserTasks";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_AssigneeID", param.UserID);
            paprameters.Add($"v_ProjectID", param.ProjectID);

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
