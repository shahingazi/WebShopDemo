using HassesWebshopCRM.API.Common;
using HassesWebshopCRM.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HassesWebshopCRM.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _repository;
        private readonly ILoggerManager _loggerManager;

        public CustomersController(ICustomerService customerRepository, ILoggerManager loggerManager)
        {
            _repository = customerRepository;
            _loggerManager = loggerManager;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await _repository.GetAllAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError(ex.StackTrace + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customer = await _repository.GetByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError(ex.StackTrace + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _repository.AddAsync(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError(ex.StackTrace + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
