using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllSafe.DataAccess.Entities;
using AllSafe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AllSafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _person;
       
        public PersonController(IPersonRepository person)
        {
            _person = person;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _person.GetAll();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<Person> Get(string id)
        {
            return await _person.Get(id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<Person> Post([FromBody] Person entity)
        {
            return await _person.Add(entity);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
