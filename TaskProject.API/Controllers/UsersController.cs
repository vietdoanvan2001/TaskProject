using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using TaskProject.BL;
using TaskProject.Common;

namespace TaskProject.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : BasesController<Users>
    {
        private readonly IUserBL _userBL;

        public UsersController(IUserBL userBL) : base(userBL)
        {
            _userBL = userBL;
        }

        #region Method

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Account body)
        {
            var serviceResult = _userBL.Login(body);

            if (serviceResult.IsSuccess == true)
            {
                return StatusCode(200, QueryResult.Success);
            }
            else
            {
                if (serviceResult.Data == Resource.Wrong_Account)
                {
                    return StatusCode(400, new ErrorResult
                    {
                        ErrorCode = ErrorCode.SqlReturnNull,
                        DevMsg = Resource.Wrong_Account,
                        UserMsg = Resource.Wrong_Account,
                        TradeId = HttpContext.TraceIdentifier,
                    });
                }
                else
                {
                    return StatusCode(500, new ErrorResult
                    {
                        ErrorCode = ErrorCode.SqlCatchException,
                        DevMsg = Resource.ServiceResult_Exception,
                        UserMsg = Resource.UserMsg_Exception,
                        TradeId = HttpContext.TraceIdentifier,
                    });
                }
            }
        }

        #endregion

    }
}
