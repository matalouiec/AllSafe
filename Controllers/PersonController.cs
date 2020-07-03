using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllSafe.Application.Interfaces;
using AllSafe.DataAccess.Entities;
using AllSafe.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AllSafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public PersonController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public Task<IEnumerable<Person>> Get()
        {
            return _unitofwork.Person.GetAll();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Task<Person> Get(string id)
        {
            return _unitofwork.Person.GetPersonById(id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public Task Post([FromBody] Person entity)
        {
            return _unitofwork.Person.Save(entity);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public Task Put(string id,[FromBody] Person entity)
        {
            return _unitofwork.Person.Put(id,entity);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public Task Delete(string id)
        {
            return _unitofwork.Person.Delete(id);
        }
    }
}
