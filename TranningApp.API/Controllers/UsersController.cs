using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranningApp.API.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace TranningApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        public readonly IZawajRepository _repo;
        public UsersController(IZawajRepository repo )
        {
            _repo = repo;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users=await _repo.GetUsers();
            return Ok(users);
        }

          [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user=await _repo.GetUser(id);
            return Ok(user);
        }

        


    }
}