using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HassesWebshopCRM.API.Model
{
    public class ProductInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableProduct { get; set; }
    }
}
