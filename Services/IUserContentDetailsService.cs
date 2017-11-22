using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface IUserContentDetailsService
    {
        Task<List<UserContentDetails>> Get();
        Task<List<UserContentDetails>> GetByID(int id);
        Task Post(UserContentDetails item);
        Task Update(int id, UserContentDetails item);
        Task Delete(int id);
    }
}