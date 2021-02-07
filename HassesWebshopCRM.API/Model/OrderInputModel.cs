using HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HassesWebshopCRM.API.Model
{
    public class OrderInputModel
    {      
        public int CustomerId { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
        public DeliveryAddressInputModel Address { get; set; }
        [JsonIgnore]
        public Order Order
        {
            get
            {
                var order = new Order
                {
                    Address = Address.ToString(),
                    CustomerId = CustomerId,
                    Status = OrderStatus.Pending,
                    CreatedAt = DateTime.Now
                   
                };

                order.OrderItems = new List<OrderItem>();
                foreach (var item in Items)
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
}
