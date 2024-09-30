using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace todo_api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
