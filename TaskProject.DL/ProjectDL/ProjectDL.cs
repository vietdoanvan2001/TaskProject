using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.DL.BaseDL;

namespace TaskProject.DL.ProjectDL
{
    public class ProjectDL : BaseDL<Project>, IProjectDL
    {
        public ServiceResult UpdateByID(Project data)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Project_Update";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add("v_ProjectName", data.ProjectName);
            paprameters.Add("v_Description", data.Description);
            paprameters.Add("v_StartDate", data.StartDate);
            paprameters.Add("v_EndDate", data.EndDate);
            paprameters.Add("v_Background", data.Background);
            paprameters.Add("v_Icon", data.Icon);
            paprameters.Add("v_ProjectID", data.ProjectId);

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
