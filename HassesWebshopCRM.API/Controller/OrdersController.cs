using HassesWebshopCRM.API.Model;
using HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HassesWebshopCRM.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderInputModel orderInputmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = ProcessOrder(orderInputmodel);
            var result = await _orderService.AddAsync(order);
            return Ok(result.OrderNumber);
        }

        private static Order ProcessOrder(OrderInputModel orderInputmodel)
        {
            var order = new Order
            {
                Address = orderInputmodel.Address.ToString(),
                CustomerId = orderInputmodel.CustomerId
            };

            order.OrderItems = new List<OrderItem>();
            foreach (var item in orderInputmodel.Items)
            {
                order.OrderItems.Add(new OrderItem
                {
                    NoOfItem = item.NoOfProduct,
                    PorductId = item.ProductId,

                });
            }

            return order;
        }

    }
}
