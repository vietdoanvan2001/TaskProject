using Dapper;
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
    public class KanbanDL : BaseDL<Kanban>, IKanbanDL
    {
        public ServiceResult getKanbanByProjectID(int projectID, Guid userID)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Kanban_GetByProjectID";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_ProjectID", projectID);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                var record = dbConnection.Query(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);
                if (record != null && record.Any())
                {
                    foreach (var item in record)
                    {
                        // chuẩn bị tên stored
                        String stored = "Proc_Tasks_GetListTask";

                        //chuẩn bị tham số đầu vào
                        var papram = new DynamicParameters();
                        papram.Add("v_ProjectID", projectID);
                        papram.Add("v_KanbanID", item.KanbanID);
                        papram.Add("v_UserID", userID);

                        var res = dbConnection.Query(stored, papram, commandType: System.Data.CommandType.StoredProcedure);
                        item.Tasks = res;
                    }
                }

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

        public ServiceResult UpdateByID(Kanban data)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Kanban_Update";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add("v_KanbanID", data.KanbanId);
            paprameters.Add("v_ColumnName", data.ColumnName);

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

        public ServiceResult UpdateSortOrder(KanbanSortOrderParam param)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Kanban_UpdateSortOrder";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add("v_ProjectId", param.ProjectID);
            paprameters.Add("v_OldIndex", param.OldIndex);
            paprameters.Add("v_NewIndex", param.NewIndex);

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
    }
}
