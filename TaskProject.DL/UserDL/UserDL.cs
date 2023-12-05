using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.Common.Enums;
using TaskProject.DL.BaseDL;

namespace TaskProject.DL
{
    public class UserDL : BaseDL<Users>, IUsersDL
    {
        public ServiceResult getUser(UserFilterParam param)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Users_FilterUsers";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_Status", param.Status);
            paprameters.Add($"v_Where", param.Keyword);
            paprameters.Add($"v_Limit", param.Limit);
            paprameters.Add($"v_Offset", param.Offset);

            //khởi tạo kết nối tới DB
            var dbConnection = GetOpenConnection();

            //thực hiện câu lệnh sql
            try
            {
                var record = dbConnection.QueryMultiple(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

                var customer = record.Read<Users>().ToList();
                var amountData = record.Read<int>().First();
                if(customer != null && customer.Any())
                {
                    foreach(var user in customer)
                    {
                        if(user.Status == (int)UserStatus.Waitting)
                        {
                            user.StatusName = Resource.Waitting;
                        }
                        else if (user.Status == (int)UserStatus.Active)
                        {
                            user.StatusName = Resource.Active;
                        }
                        else
                        {
                            user.StatusName = Resource.InActive;
                        }
                    }
                }

                //đóng kết nối tới db
                dbConnection.Close();

                var res = new Dictionary<string, object>{
                    { "PageData", customer},
                    { "Total", amountData },
                    };

                if (res != null)
                {
                    return new ServiceResult(true, res);
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

        public ServiceResult Login(Account acc)
        {
            // chuẩn bị tên stored
            String storedProcedureName = $"Proc_Users_Login";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_UserName", acc.UserName);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                Users record = dbConnection.QueryFirstOrDefault<Users>(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

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
            catch (Exception e)
            {

                return new ServiceResult(false, e);
            }
        }

        public ServiceResult getUserByListID(string listID)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Users_GetInListID";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_ListID", listID);

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

        public ServiceResult getUserByID(Guid id)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Users_GetByUserID";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_UserID", id);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                var record = dbConnection.QueryFirstOrDefault(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

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

        public ServiceResult DeleteByListID(string listID)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Users_MultipleDelete";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add("v_ListUserID", listID);

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

        public ServiceResult UpdateStatus(UpdateUserStatus param)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Users_UpdateStatus";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_ListUserID", param.ListID);
            paprameters.Add($"v_Status", param.Status);

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

        public ServiceResult AddToTrash(UpdateUserStatus param)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Users_AddToTrash";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add("v_ListUserID", param.ListID);
            paprameters.Add("v_Status", param.Status);

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

        public ServiceResult GetUsersInTrash()
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Users_GetTrash";

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                var record = dbConnection.Query(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

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

        public ServiceResult UpdatePassword(UpdatePasswordParam param)
        {
            // chuẩn bị tên stored
            String storedProcedureName = "Proc_Users_UpdatePassword";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_Id", param.Id);
            paprameters.Add($"v_NewPassword", param.NewPassword);

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
