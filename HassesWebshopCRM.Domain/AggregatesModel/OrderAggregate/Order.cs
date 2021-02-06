using HassesWebshopCRM.Domain.AggregatesModel.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get { return new Guid().ToString(); } }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        private DateTime CreatedAt => DateTime.Now;
    }
}
