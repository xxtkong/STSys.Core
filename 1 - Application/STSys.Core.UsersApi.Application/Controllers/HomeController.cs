using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Users.Abstractions.Entities;
using STSys.Core.Users.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.UsersApi.Application.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsersRepository _users;
        public HomeController(IMediator mediator, IUsersRepository users)
        {
            this._mediator = mediator;
            this._users = users;
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<UsersEntities> GetUsers()
        {
            var result = _users.GetAll();
            return result;
        }



        /// <summary>
        /// 多播模式例子
        /// </summary>
        [Route("TestNotificationHandler")]
        [HttpGet]
        public void TestNotificationHandler()
        {
            //_mediator.Publish(new TestNotificationCommand());
        }


        
    }
}
