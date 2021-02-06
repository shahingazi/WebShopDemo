namespace HassesWebshopCRM.API.Model
{
    public class DeliveryAddressInputModel
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return $"{Name},{Street},{Country},{City},{PostalCode}";
        }
    }
}