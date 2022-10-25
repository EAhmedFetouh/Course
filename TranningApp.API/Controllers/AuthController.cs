using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TranningApp.API.Dtos;
using TranningApp.API.IRepository;
using TranningApp.API.Models;

namespace TranningApp.API.Controllers
{ 
     [ApiController]
    [Route("api/[controller]")]
    // [DebuggerDisplay("{" + nameo
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _Repo ;
        private readonly IConfiguration _IConfig ;
        public AuthController(IAuthRepository repo , IConfiguration IConfig)
        {
            _Repo = repo;
            _IConfig=IConfig;
            
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
                userRegisterDto.UserName = userRegisterDto.UserName.ToLower();
                if(await _Repo.UserExists(userRegisterDto.UserName))
                return BadRequest("هذا المستخدم مسجل من قبل");

                var UserCreate = new User{
                    UserName=userRegisterDto.UserName
                };

                var CreatedUser = await _Repo.Register(UserCreate , userRegisterDto.Password);
                    
                return StatusCode(201);


        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto){
            var user = await _Repo.Login(userForLoginDto.UserName , userForLoginDto.Password);
            if(user == null) return Unauthorized();

               var claims = new []{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.UserName)
               } ;

               var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_IConfig.GetSection("AppSettings:Token").Value));
               var creds = new SigningCredentials(Key , SecurityAlgorithms.HmacSha512);
               var tokenDescriptor = new SecurityTokenDescriptor {
                Subject= new ClaimsIdentity(claims),
                Expires=DateTime.Now.AddDays(1),
                SigningCredentials=creds
               };

               var tokenHandler = new JwtSecurityTokenHandler ();
               var token = tokenHandler.CreateToken(tokenDescriptor);

               return Ok (new {
                    token=tokenHandler.WriteToken(token)
               });

        }
    }
}