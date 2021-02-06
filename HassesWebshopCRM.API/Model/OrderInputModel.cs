
using HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HassesWebshopCRM.API.Model
{
    public class OrderInputModel
    {
        public int CustomerId { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
        public DeliveryAddressInputModel Address { get; set; }
    }
}
