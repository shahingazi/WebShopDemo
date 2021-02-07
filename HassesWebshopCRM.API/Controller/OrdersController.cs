using HassesWebshopCRM.API.Common;
using HassesWebshopCRM.API.Model;
using HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate;
using HassesWebshopCRM.Domain.AggregatesModel.ProductAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HassesWebshopCRM.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ILoggerManager _loggerManager;

        public OrdersController(IOrderService orderService,
            IProductService productService, ILoggerManager loggerManager)
        {
            _orderService = orderService;
            _productService = productService;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var orderDetailsModel = new OrderDetailsModel();
                var orders = _orderService.GetAll();
                return Ok(orderDetailsModel.Map(orders));
            }
            catch (Exception ex)
            {
                _loggerManager.LogError(ex.StackTrace + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public string Get(int orderNumber)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderInputModel orderInputmodel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                foreach (var item in orderInputmodel.Items)
                {
                    var product = await _productService.GetByIdAsync(item.ProductId);
                    product.AvailableProduct -= item.NoOfProduct;
                    if (product.AvailableProduct < 0)
                        return NotFound(product);
                    await _productService.UpdateAsync(product);
                }

                var result = await _orderService.AddAsync(orderInputmodel.Order);
                return Ok(result.OrderNumber);

            }
            catch (Exception ex)
            {
                _loggerManager.LogError(ex.StackTrace + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


    }
}
