﻿using System.ComponentModel.DataAnnotations;

namespace HassesWebshopCRM.Domain.AggregatesModel.ProductAggregate
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableProduct { get; set; }
    }
}
