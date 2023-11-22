using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskProject.BL;
using TaskProject.BL.BaseBL;
using TaskProject.BL.ProjectBL;
using TaskProject.Common;
using TaskProject.Common.Entities;

namespace TaskProject.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectsController : BasesController<Project>
    {
        private readonly IProjectBL _projectBL;
        public ProjectsController(IProjectBL projectBL) : base(projectBL)
        {
            _projectBL = projectBL;
        }

        [HttpPut("UpdateByID/{id}")]
        public IActionResult getUser([FromBody] Project data)
        {
            var serviceResult = _projectBL.UpdateByID(data);
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
