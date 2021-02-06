﻿using HassesWebshopCRM.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _baseRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IRepository<Order> baserepository, IOrderRepository orderRepository)
        {
            _baseRepository = baserepository;
            _orderRepository = orderRepository;
        }
        
        public Task<Order> AddAsync(Order order)
        {
            return _baseRepository.AddAsync(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAllOrders();
        }        
    }
}
