using System.Collections.Generic;
using System.Threading.Tasks;

namespace HassesWebshopCRM.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Task<Order> AddAsync(Order order);
    }
}
