using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskProject.BL.BaseBL;
using TaskProject.BL.KanbanBL;
using TaskProject.BL.ProjectBL;
using TaskProject.Common;
using TaskProject.Common.Entities;

namespace TaskProject.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class KanbansController : BasesController<Kanban>
    {
        private readonly IKanbanBL _kanbanBL;
        public KanbansController(IKanbanBL kanbanBL) : base(kanbanBL)
        {
            _kanbanBL = kanbanBL;
        }

        [HttpGet("GetKanbanByProjectID/{id}")]
        public IActionResult getUser([FromRoute] int id)
        {
            var serviceResult = _kanbanBL.getKanbanByProjectID(id);
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
        public IActionResult updateByID([FromBody] Kanban data)
        {
            var serviceResult = _kanbanBL.UpdateByID(data);
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

        [HttpPut("UpdateSortOrder")]
        public IActionResult updateSortOrder([FromBody] KanbanSortOrderParam param)
        {
            var serviceResult = _kanbanBL.UpdateSortOrder(param);
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
