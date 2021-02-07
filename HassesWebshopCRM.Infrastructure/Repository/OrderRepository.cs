﻿using HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HassesWebshopCRM.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CRMDbContext _dbContext;

        public OrderRepository(CRMDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<Order>  GetAllOrders()
        {
            return _dbContext.Orders
                .Include(x=>x.Customer)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product);
        }

        public int GetLastOrderId()
        {
            if (_dbContext.Orders.Count() ==0)
                return 0;
          
            return _dbContext.Orders.Max(x=>x.Id);
        }
    }
}
