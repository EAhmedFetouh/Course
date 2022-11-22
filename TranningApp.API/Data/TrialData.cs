using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TranningApp.API.Data;
using TranningApp.API.Models;

namespace TranningApp.API.Data
{

    public  class TrialData
    {
        public readonly DataContext _Context ;
        public  TrialData(DataContext context)
        {
           _Context= context;
            
        }

        public  void TrialUsers(){
                var userData=System.IO.File.ReadAllText("Data/UserTrialData.json");
                var users=JsonConvert.DeserializeObject<List<User>> (userData);
                foreach(var user in users)
                {
                    byte[] PasswordHash, PasswordSalt;

                    CreatePasswordHash("password",out PasswordHash,out PasswordSalt);
                    user.PasswordHash=PasswordHash;
                    user.PasswordSalt=PasswordSalt;
                    user.Username=user.Username.ToLower();

                    _Context.Add(user);
                }
                _Context.SaveChanges();
        }
          private  void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }
    }

    
}