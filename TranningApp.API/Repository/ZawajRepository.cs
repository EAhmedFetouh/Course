using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranningApp.API.Data;
using TranningApp.API.IRepository;
using TranningApp.API.Models;

namespace TranningApp.API.Repository
{
    public class ZawajRepository : IZawajRepository
    {
        public readonly DataContext _Context ;
        public ZawajRepository(DataContext context)
        {
            _Context = context;
            
        }
        public void Add<T>(T entity) where T : class
        {
           _Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _Context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user= await _Context.Users.Include(x=>x.Photos).FirstOrDefaultAsync(u=>u.Id==id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
           var users= await _Context.Users.Include(x=>x.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
           return await _Context.SaveChangesAsync()>0;
        }
    }
}