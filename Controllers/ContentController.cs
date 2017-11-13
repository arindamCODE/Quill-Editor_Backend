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
    public class ContentController : Controller
    {
        private IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public Task<List<ContentTable>> GetAll()
        {
            return _contentService.Get();
        }

        [HttpGet("{id}")]
        public Task<List<ContentTable>> GetID(int id)
        {
            Console.WriteLine(id);
            
           Task<List<ContentTable>> tempVar= _contentService.GetByID(id);
           Console.WriteLine(tempVar);
            return tempVar;
        }

        [HttpPost]
        public void PostNew([FromBody] ContentTable item)
        {
            _contentService.Post(item);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ContentTable item)
        {
           _contentService.Update(id, item);
        }

        [HttpDelete("{id}")]
        public void Del(int id)
        {
            _contentService.Delete(id);
        }
    }
}
