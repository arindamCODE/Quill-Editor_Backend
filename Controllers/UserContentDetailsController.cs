using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [Route("api/[controller]")]
    public class UserContentDetailsController : Controller
    {
        private IUserContentDetailsService _service;

        public UserContentDetailsController(IUserContentDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<List<UserContentDetails>> GetAll()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public Task<List<UserContentDetails>> GetID(int id)
        {
            return  _service.GetByID(id); 
        }

        [HttpPost]
        public void PostNew([FromBody] UserContentDetails item)
        {
            _service.Post(item);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserContentDetails item)
        {
           _service.Update(id, item);
        }

        [HttpDelete("{id}")]
        public void Del(int id)
        {
            _service.Delete(id);
        }
    }
}