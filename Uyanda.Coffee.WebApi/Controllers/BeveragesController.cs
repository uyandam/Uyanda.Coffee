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
        

        [HttpGet]
        public string Get() => "Congrats! You have hit the API!!!";

      
        [HttpPost("addbeveragecost")]
        public async Task<IActionResult> AddBeverageCostAsync([FromBody] AddBeverageCostCommand command)
        {
            try
            {
                var result = await beverageManagementService.AddBeverageCostAsync(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("getbeveragecost")]
        public async Task<IActionResult> GetBeverageCostAsync()
        {
            try
            {
                var result = await beverageManagementService.GetBeverageCostAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("PurchaseBeverages")]
        public async Task<IActionResult> PurchaseAsync([FromBody] PurchaseCommand command)
        {
            try
            {
                var result = await beverageManagementService.PurchaseAsync(command);
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("AddBeverageSizeCost")]
        public async Task<IActionResult> UpsertBeverageSizeCostAsync([FromBody] AddBeverageSizeCostCommand command)
        {
            try
            {
                var result = await beverageManagementService.UpsertBeverageSizeCostAsync(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
