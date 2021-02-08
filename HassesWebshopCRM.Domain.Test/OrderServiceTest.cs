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
        public async Task AddOrderSuccessfullyAsyncTest()
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

            var returnOrder = new Order
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

            _mockorderRepository.Setup(repo => repo.GetLastOrderId()).Returns(2);
            _mockbaserepository.Setup(repo => repo.AddAsync(orderInput)).Returns(Task.Run(() => returnOrder));
            var service = new OrderService(_mockbaserepository.Object, _mockorderRepository.Object);
            var order = await service.AddAsync(orderInput);
            _mockbaserepository.Verify(x => x.AddAsync(It.Is<Order>(actualOrder => actualOrder.OrderNumber == "SO1002")), Times.Once);
            Assert.Equal(returnOrder, order);
        }


    }
}
