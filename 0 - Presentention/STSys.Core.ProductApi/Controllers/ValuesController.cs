using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Product.Abstractions.Entities;
using STSys.Core.Product.Abstractions.Specifications;

namespace STSys.Core.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRepositoryEF<ProductEntities> _repository;
        public ValuesController(IRepositoryEF<ProductEntities> repository)
        {
            _repository = repository;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //var many = _repository.GetAll();
            var basketSpec = new ProductItemSpecification(Guid.Parse("8DF48AC2-375D-4830-4016-08D7584F725A"));
            var Criteria = basketSpec.Criteria;
            var Includes = basketSpec.Includes;
            var IncludeStrings = basketSpec.IncludeStrings;

            var many = _repository.GetMany(basketSpec);
            var c = many.First().Items.Count();
            return Ok(many.First().Title);
        }

    }
}
