using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using MySqlConnector;
using TaskProject.BL;
using TaskProject.Common;
using TaskProject.Common.Entities;

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
                return StatusCode(200, serviceResult.Data);
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

        [HttpPost("GetFilterUsers")]
        public IActionResult getUser([FromBody] UserFilterParam param)
        {
            var serviceResult = _userBL.getUser(param);
            if (serviceResult.IsSuccess == true)
            {
                return StatusCode(200, serviceResult.Data);
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

        [HttpGet("GetUsersInTrash")]
        public IActionResult getUsersInTrash()
        {
            var serviceResult = _userBL.GetUsersInTrash();
            if (serviceResult.IsSuccess == true)
            {
                return StatusCode(200, serviceResult.Data);
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

        [HttpPost("GetByListID")]
        public IActionResult getUserByListID([FromBody] MultipleParams param)
        {
            var serviceResult = _userBL.getUserByListID(param.listID);
            if (serviceResult.IsSuccess == true)
            {
                return StatusCode(200, serviceResult.Data);
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

        [HttpPost("DeleteByListID")]
        public IActionResult deleteUserByListID([FromBody] MultipleParams param)
        {
            var serviceResult = _userBL.DeleteByListID(param.listID);
            if (serviceResult.IsSuccess == true)
            {
                return StatusCode(200, serviceResult.Data);
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

        [HttpPost("AddToTrash")]
        public IActionResult addToTrash([FromBody] UpdateUserStatus param)
        {
            var serviceResult = _userBL.AddToTrash(param);
            if (serviceResult.IsSuccess == true)
            {
                return StatusCode(200, serviceResult.Data);
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

        [HttpPost("UpdateStatus")]
        public IActionResult updateStatus([FromBody] UpdateUserStatus param)
        {
            var serviceResult = _userBL.UpdateStatus(param);
            if (serviceResult.IsSuccess == true)
            {
                return StatusCode(200, serviceResult.Data);
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

        [HttpPost("UpdatePassword")]
        public IActionResult updatePassword([FromBody] UpdatePasswordParam param)
        {
            var serviceResult = _userBL.UpdatePassword(param);
            if (serviceResult.IsSuccess == true)
            {
                return StatusCode(200, serviceResult.Data);
            }
            else
            {
                if (serviceResult.Data == Resource.Wrong_Account)
                {
                    return StatusCode(400, new ErrorResult
                    {
                        ErrorCode = ErrorCode.SqlReturnNull,
                        DevMsg = Resource.Wrong_Pass,
                        UserMsg = Resource.Wrong_Pass,
                        TradeId = HttpContext.TraceIdentifier,
                    });
                }
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = ErrorCode.SqlCatchException,
                    DevMsg = Resource.ServiceResult_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TradeId = HttpContext.TraceIdentifier,
                });
            }
        }

        [HttpGet("GetByID/{id}")]
        //[Authorize]
        public IActionResult getUserByID([FromRoute] Guid id)
        {
            var serviceResult = _userBL.getUserByID(id);
            if (serviceResult.IsSuccess == true)
            {
                return StatusCode(200, serviceResult.Data);
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
        #endregion

    }
}
