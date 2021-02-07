using HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HassesWebshopCRM.API.Model
{
    public class OrderDetailsModel
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DeliveryAddress { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItemDetailsModel> Items { get; set; }

        public IEnumerable<OrderDetailsModel> Map(IEnumerable<Order> orders)
        {
            return orders.Select(x => new OrderDetailsModel
            {
                OrderNumber = x.OrderNumber,
                CustomerName = x.Customer.Name,
                DeliveryAddress = x.Address,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                Items = x.OrderItems.Select(x => new OrderItemDetailsModel
                {
                    ItemId = x.Id,
                    Title = x.Product.Title,
                    NoOfItems = x.NoOfItem,
                    Price = x.Product.Price,
                    TotalPrice = x.Amount
                }).ToList()
            });
        }
    }
}
