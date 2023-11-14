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
            catch (Exception)
            {

                return new ServiceResult(false, Resource.ServiceResult_Exception);
            }
        }
    }
}
