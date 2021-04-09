using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Services;
using Microsoft.Extensions.Configuration;

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

        [HttpPost("GetBeveragePrices")]
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

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrderAsync([FromBody] PlaceOrderCommand command)
        {
            try
            {
                var result = await beverageManagementService.PlaceOrderAsync(command);

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomerAsync([FromBody] AddCustomerCommand command)
        {
            try
            {
                var result = await beverageManagementService.AddCustomerAsync(command);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("GetCustomer")]
        public async Task<IActionResult> GetCustomerAsync([FromBody] GetCustomerCommand command)
        {
            try
            {
                var result = await beverageManagementService.GetCustomerAsync(command);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("GetCustomerId")]
        public async Task<IActionResult> GetCustomerIdAsync([FromBody] GetCustomerCommand command)
        {
            try
            {
                var result = await beverageManagementService.GetCustomerIdAsync(command);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> PayAsync([FromBody] PayCommand command)
        {
            try
            {
                var result = await beverageManagementService.PayAsync(command);

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}
