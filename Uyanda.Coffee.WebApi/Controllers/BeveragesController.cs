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

        [HttpPost("ListBeverages")]
        public async Task<IActionResult> ListBeverages([FromBody] GetBeveragesQuery query)
        {
            try
            {
                
                var rahl = await beverageManagementService.GetBeveragesAsync(query);
                return Ok(rahl);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e);
            }
            
        }


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

       
        [HttpPost("getavailablecups")]
        public async Task<IActionResult> Getavailablecups()
        {
            try
            {
                var result = await beverageManagementService.AvailableCoffeeCupsAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e);
            }
        }
    }
}
