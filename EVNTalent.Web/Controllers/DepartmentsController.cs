namespace EVNTalent.Web.Controllers
{
using EVNTalent.Services.DepartmentCommands.Commands;
using EVNTalent.Services.DepartmentCommands.Query.DepartmentList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
    [Route("api/department")]
    public class DepartmentsController : ApiController
    {
        public DepartmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetListController()
        {
            var result = await _mediator.Send(new DepartmentListQuery { }); 
            return Ok(result);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddDepartment(AddDepartmentsCommand addDepartment)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(addDepartment);
            return Ok(result);
        }
    }
}
