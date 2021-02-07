using HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate;
using HassesWebshopCRM.Domain.SeedWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HassesWebshopCRM.Domain.Test
{
    public class OrderServiceTest
    {
        private readonly Mock<IRepository<Order>> _mockbaserepository;
        private readonly Mock<IOrderRepository> _mockorderRepository;

        public OrderServiceTest()
        {
            _mockbaserepository = new Mock<IRepository<Order>>();
            _mockorderRepository = new Mock<IOrderRepository>();

        }

        [Fact]
        public async Task AddOrderSuccessfullyAsync()
        {
            var orderInput = new Order
            {
                CustomerId = 1,
                Address = "Albatrosvagern",
                CreatedAt = DateTime.Now,
                Status = OrderStatus.Pending,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        NoOfItem =10,
                        PorductId =1,
                    }
                }
            };
            
            _mockorderRepository.Setup(repo => repo.GetLastOrderId()).Returns(1);            
            var service = new OrderService(_mockbaserepository.Object, _mockorderRepository.Object);

            var order = await service.AddAsync(orderInput);
            
            Assert.Equal("SO1001", orderInput.OrderNumber);
        }
    }
}
