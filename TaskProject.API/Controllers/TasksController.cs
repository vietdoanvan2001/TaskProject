using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskProject.BL.KanbanBL;
using TaskProject.BL.TaskBL;
using TaskProject.Common;
using TaskProject.Common.Entities;

namespace TaskProject.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TasksController : BasesController<Tasks>
    {
        private readonly ITaskBL _taskBL;
        public TasksController(ITaskBL taskBL) : base(taskBL)
        {
            _taskBL = taskBL;
        }

        [HttpGet("GetTaskByProjectID/{id}")]
        public IActionResult getUser([FromRoute] int id)
        {
            var serviceResult = _taskBL.getKanbanByProjectID(id);
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

        [HttpPut("UpdateByID/{id}")]
        public IActionResult updateByID([FromBody] Tasks data)
        {
            var serviceResult = _taskBL.UpdateByID(data);
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

        [HttpPut("UpdateProcess")]
        public IActionResult updateProcess([FromBody] UpdateTaskProcessParam param)
        {
            var serviceResult = _taskBL.UpdateProcess(param);
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

        [HttpPut("UpdateKanban")]
        public IActionResult updateKanban([FromBody] UpdateTaskProcessParam param)
        {
            var serviceResult = _taskBL.UpdateKanban(param);
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
    }
}
