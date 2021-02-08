using HassesWebshopCRM.API.Model;
using HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate;
using System.Collections.Generic;
using Xunit;

namespace HassesWebshopCRM.API.Test
{
    public class OrderInputModelTest    {

        private readonly OrderInputModel _orderInputModel;

        public OrderInputModelTest()
        {
            _orderInputModel = new OrderInputModel
            {
                CustomerId = 1,
                Address = new DeliveryAddressInputModel
                {
                    City = "Stockholm",
                    Country = "Sweden",
                    Name = "Shahin",
                    PostalCode = "1366",
                    Street = "Albatrossvagen 76"
                },
                Items = new List<OrderItemInputModel>
                {
                    new OrderItemInputModel
                    {
                        NoOfProduct = 1,
                        ProductId =1
                    }
                }

            };
        }

        [Fact]
        public void OrderStatusShouldBePending()
        {
            Assert.Equal(OrderStatus.Pending, _orderInputModel.Order.Status);
        }

        [Fact]
        public void AddressShouldBeMatched()
        {
            Assert.Equal("Shahin,Albatrossvagen 76,Sweden,Stockholm,1366", _orderInputModel.Order.Address);
        }
    }
}
