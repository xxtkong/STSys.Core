using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Users.Abstractions.Entities;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IRepositoryEF<ManagerEntities> _repository;
       private readonly IRepository<ManagerEntities> _repository;
        public HomeController(IRepository<ManagerEntities> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var count = _repository.GetAll();
            return Content(count.First().Name);
        }
    }
}
