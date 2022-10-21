using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranningApp.API.Data;
using Microsoft.EntityFrameworkCore;
using TranningApp.API.Models;

namespace TranningApp.API.Controllers ; 

    [ApiController]
    [Route("api/[controller]")]
    // [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class ValuesController : ControllerBase
{
        private readonly DataContext DbContext ;
    
    public ValuesController(DataContext DbContext)
    {
            this.DbContext = DbContext;
        
    }


    // GET api/Values

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Value))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetValues()
    {
            var values =await DbContext.Values.ToListAsync();
            return Ok(values);
    }


// GET api/Values /5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Value))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetValue(int id)
    {
            var value =await DbContext.Values.FirstOrDefaultAsync(x=>x.Id==id);
            return Ok(value);
    }
     private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
   
