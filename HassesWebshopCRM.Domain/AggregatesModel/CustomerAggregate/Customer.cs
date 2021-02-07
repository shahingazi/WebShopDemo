
using System.ComponentModel.DataAnnotations;

namespace HassesWebshopCRM.Domain.AggregatesModel.CustomerAggregate
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
