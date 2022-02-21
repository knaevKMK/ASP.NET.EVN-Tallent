namespace EVNTalent.Web.Controllers
{
using MediatR;
using Microsoft.AspNetCore.Mvc;
  
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
