using Microsoft.AspNetCore.Mvc;
using STSys.Core.Domain.Catalog.Entities;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.UsersApi.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.UsersApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController: ControllerBase
    {
        private readonly IRepository<Product> _repository;
        public ListController(IRepository<Product> repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        [Route("lists")]
        public IEnumerable<ListViewModel> Lists()
        {
            return null;
        }
    }
}
