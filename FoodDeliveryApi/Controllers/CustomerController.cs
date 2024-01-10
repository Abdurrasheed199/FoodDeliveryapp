using FoodDeliveryApi.DTO_s.CustomerDTO;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace FoodDeliveryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) => (_customerService) = (customerService);
        [HttpPost("CustomerRegistration")]
        public async Task<IActionResult> Create([FromForm] CreateCustomerRequestModel model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var customer = await _customerService.CreateCustomer(model,cancellationToken);
            if (customer.Status == false) 
            return BadRequest(customer);

            return Ok(customer);
        }
    }
}
