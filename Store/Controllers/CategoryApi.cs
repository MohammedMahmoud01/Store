using Microsoft.AspNetCore.Mvc;
using Store.Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApi : ControllerBase
    {
        IClsItemsCat ctx;
        public CategoryApi(IClsItemsCat service)
        {
            ctx = service;
        }
        // GET: api/<CategoryApi>
        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            return ctx.GetAllCategories();
        }

        // GET api/<CategoryApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
