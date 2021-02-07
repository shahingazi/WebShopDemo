using System.ComponentModel.DataAnnotations;

namespace HassesWebshopCRM.API.Model
{
    public class DeliveryAddressInputModel
    {
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return $"{Name},{Street},{Country},{City},{PostalCode}";
        }
    }
}