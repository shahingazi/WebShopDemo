namespace HassesWebshopCRM.API.Model
{
    public class OrderItemDetailsModel
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int NoOfItems { get; set; }
        public decimal TotalPrice { get; set; }

    }
}