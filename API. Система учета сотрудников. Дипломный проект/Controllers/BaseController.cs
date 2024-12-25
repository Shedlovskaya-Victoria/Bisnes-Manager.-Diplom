using System;
using System.Security.Claims;
using BisnesManager.DatabasePersistens.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BisnesManager.WebAPI.Diplom
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        private int userId;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal int UserId {
            get
            {
                if (!User.Identity.IsAuthenticated  || userId == 0)
                    return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                return userId;
            }
            set => userId = value; 
        }
    }
}
