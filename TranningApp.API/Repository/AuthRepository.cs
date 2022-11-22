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
    public class AuthRepository : IAuthRepository
    {
     private readonly DataContext DbContext ;
    
    public AuthRepository(DataContext DbContext)
    {
            this.DbContext = DbContext;
    }        
        public async Task<User> Login(string UserName, string Password)
        {
           var user = await DbContext.Users.FirstOrDefaultAsync(x=>x.Username == UserName);
           if(user ==  null) return null;
           if(!VerfiyPasswordHash(Password , user.PasswordSalt, user.PasswordHash)) return null;

           return user;
        }

        private bool VerfiyPasswordHash(string password, byte[]? passwordSalt, byte[]? passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var ComputeHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
               for   (int i=0 ; i< ComputeHash.Length  ; i++)
               {
                    if(ComputeHash[i] != passwordHash[i]){
                        return false;
                    }
                    else{
                        return true;
                    }
               }
                return true;
            }
        }

        public async Task<User> Register(User user, string Password)
        {
            byte[] PasswordHash , PasswordSalt;
            CreatePasswordHash(Password , out PasswordHash , out PasswordSalt);
            user.PasswordSalt=PasswordSalt;
            user.PasswordHash=PasswordHash;

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        public async Task<bool> UserExists(string UserName)
        {
            if(await DbContext.Users.AnyAsync(x=>x.Username==UserName))
            {
                return  true;
            }
            else{
                return false;
            }
        }
    }
}