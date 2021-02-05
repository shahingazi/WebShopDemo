using System.Collections.Generic;
using System.Threading.Tasks;

namespace HassesWebshopCRM.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> GetByIdAsync(int Id);
    }
}
