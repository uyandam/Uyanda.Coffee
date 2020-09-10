using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Services;

namespace Uyanda.Coffee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        private readonly IBeverageManagementService beverageManagementService;

        public BeveragesController(IBeverageManagementService beverageManagementService)
        {
            this.beverageManagementService = beverageManagementService;
        }
        
        // Get methods
        [HttpGet]
        public string Get() => "Congrats! You have hit the API!!!";

        [HttpGet("ListBeverages")]
        public async Task<IActionResult> ListBeverages()
        {
            try
            {
                GetBeveragesQuery query = new GetBeveragesQuery();
                
                var rahl = beverageManagementService.GetBeveragesAsync();
                Console.WriteLine("Start toxic");
                Console.WriteLine(rahl);
                Console.WriteLine("Remain toxic");
                return Ok(rahl);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e);
            }
            //var rahl = beverageManagementService.GetBeveragesAsync(query);
            
        }

        //Post methods

        [HttpPost("AddBeverages")]
        public async Task<IActionResult> AddBeveragesAsync([FromBody] AddBeveragesCommand command)
        {
            try
            {
                var result = await beverageManagementService.AddBeveragesAsync(command);

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
