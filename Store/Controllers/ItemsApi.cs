using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Bl;
using Store.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsApi : ControllerBase
    {
        IClsItemsCat ctx;
        public ItemsApi(IClsItemsCat service)
        {
            ctx = service;
        }
        // GET: api/<ItemsApi>
        [HttpGet]
        public IEnumerable<ItemsApiModel> Get()
        {
            return ctx.GetAllItems();
        }

        // GET api/<ItemsApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemsApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemsApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemsApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
