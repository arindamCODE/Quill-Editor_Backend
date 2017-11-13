using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface IContentService
    {
        Task<List<ContentTable>> Get();
        Task<List<ContentTable>> GetByID(int id);
        Task Post(ContentTable item);
        Task Update(int id, ContentTable item);
        Task Delete(int id);
    }
}