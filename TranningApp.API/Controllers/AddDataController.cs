using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TranningApp.API.Data;
using TranningApp.API.Dtos;
using TranningApp.API.IRepository;
using TranningApp.API.Models;

namespace TranningApp.API.Controllers
{ 
     [ApiController]
    [Route("api/[controller]")]
    // [DebuggerDisplay("{" + nameo
    public class AddDataController : ControllerBase
    {
         public readonly DataContext _Context ;
        
        public AddDataController(DataContext Context)
        {
          _Context= Context;
            
        }


        [HttpPost("SetData")]
        public IActionResult SetData()
        {
                TrialData data = new TrialData(_Context);
                data.TrialUsers();
                 return Ok ();

        }
    }
}