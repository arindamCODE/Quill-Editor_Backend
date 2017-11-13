using System;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ContentService : IContentService
    {
        private ContentContext _context;
        public ContentService(ContentContext context)
        {
            _context = context;
        }
        public async Task<List<ContentTable>> Get()
        {
            return await _context.ContentTable.ToListAsync();
        }
        public async Task<List<ContentTable>> GetByID(int id)
        {
            ContentTable objectScore = await _context.ContentTable.FirstOrDefaultAsync(pi => pi.ID == id);
            Console.WriteLine("From Service");
            Console.WriteLine(objectScore.ID);
            
            List<ContentTable> product = new List<ContentTable>();
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
        public async Task Post(ContentTable item)
        {
            try
            {
                _context.ContentTable.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task Update(int id, ContentTable item)
        {
            try
            {
                var result = _context.ContentTable.FirstOrDefault(t => t.ID == id);
                result.Content = item.Content;
                result.MetaTags = item.MetaTags;
                result.Favourites = item.Favourites;
                result.Users = item.Users;
                _context.ContentTable.Update(result);
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
                var result = _context.ContentTable.FirstOrDefault(t => t.ID == id);
                _context.ContentTable.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}