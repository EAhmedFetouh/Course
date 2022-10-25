using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranningApp.API.Models;

namespace TranningApp.API.IRepository
{
    public interface IAuthRepository
    {
        Task <User> Register(User user , string Password);
        Task <User> Login(string UserName , string Password);
        Task <bool> UserExists (string UserName);
    }
}