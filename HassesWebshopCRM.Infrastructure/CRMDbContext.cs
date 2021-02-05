﻿using HassesWebshopCRM.Domain.AggregatesModel.CustomerAggregate;
using HassesWebshopCRM.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;

namespace HassesWebshopCRM.Infrastructure
{
    public class CRMDbContext: DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
      
    }
}
