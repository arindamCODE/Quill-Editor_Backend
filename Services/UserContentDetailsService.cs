using System;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class UserContentDetailsService : IUserContentDetailsService
    {
        private UserContentDetailsContext _context;
        public UserContentDetailsService(UserContentDetailsContext context)
        {
            _context = context;
        }
        public async Task<List<UserContentDetails>> Get()
        {
            return await _context.UserContentDetails.ToListAsync();
        }
        public async Task<List<UserContentDetails>> GetByID(int id)
        {
            UserContentDetails objectScore = await _context.UserContentDetails.FirstOrDefaultAsync(pi => pi.ContentId == id);
            
            List<UserContentDetails> product = new List<UserContentDetails>();
            try
            {
                product.Add(objectScore);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public async Task Post(UserContentDetails item)
        {
            try
            {
                item.CreatedOn = System.DateTime.Now;
                item.ModifiedOn = System.DateTime.Now;
                
                _context.UserContentDetails.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task Update(int id, UserContentDetails item)
        {
            try
            {
                var result = _context.UserContentDetails.FirstOrDefault(t => t.ContentId == id);

                result.Content = item.Content;
                result.MetaTags = item.MetaTags;
                result.IsPrivate = item.IsPrivate;
                result.IsGraphCreated = item.IsGraphCreated;
                result.IsFavourites = item.IsFavourites;
                result.IsDelete = item.IsDelete;
        
                _context.UserContentDetails.Update(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                var result = _context.UserContentDetails.FirstOrDefault(t => t.ContentId == id);
                _context.UserContentDetails.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}