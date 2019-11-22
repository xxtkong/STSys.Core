using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.UsersApi.Application.Controllers
{
    [Authorize(Roles = "consultant")]
    public abstract class ConsultantBaseController : ApiController
    {
    }
}
