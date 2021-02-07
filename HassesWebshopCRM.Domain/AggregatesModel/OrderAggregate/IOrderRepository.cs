using System.Collections.Generic;

namespace HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        int GetLastOrderId();
    }
}
