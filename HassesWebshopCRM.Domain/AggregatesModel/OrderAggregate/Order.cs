using HassesWebshopCRM.Domain.AggregatesModel.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        [NotMapped]
        public int LastOrderNumber { get; set; }
        public string NextOrderNumber { get { return $"SO{LastOrderNumber + 1000}"; } }
    }
}
