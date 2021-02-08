using HassesWebshopCRM.Domain.AggregatesModel.ProductAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int PorductId { get; set; }
        public int NoOfItem { get; set; }       
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("PorductId")]
        public Product Product { get; set; }
    }
}
