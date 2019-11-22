using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using STSys.Core.Cache.RedisHelper;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.UsersApi.Application.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.UsersApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="company")]
    public class ValuesController : ControllerBase
    {
        //private readonly IRepositoryMongoDB<TestViewModel> _repositoryMongoDB;
        //public ValuesController(IRepositoryMongoDB<TestViewModel> repositoryMongoDB)
        //{
        //    this._repositoryMongoDB = repositoryMongoDB;
        //}
        //[HttpGet]
        ////[STAuthorize("admin")]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    var claims = HttpContext.User.Claims;
        //    return new string[] { "111", "222" };
        //}

        //[Route("MongoDBTest")]
        //[HttpGet]
        //public async Task<IActionResult> Mapper()
        //{
        //    var result = await _repositoryMongoDB.GetAll();
        //    //测试下修改
        //    //await _repositoryMongoDB.Update(s => s.id == 1, new TestViewModel() { id = 1, Name = "历史" });
        //    ////测试
        //    //var update = Builders<TestViewModel>.Update.Set(s => s.Name, "王五");
        //    //await _repositoryMongoDB.Update(s => s.id == 1, update);


        //    return Ok(result);
        //}

        //[HttpGet]
        //[Route("RedisTest")]
        //public IActionResult RedisTest()
        //{
        //    var model = StackExchangeRedisHelper.Instance().Get("nacategory");
        //    return Ok(model);
        //}
    }
}
