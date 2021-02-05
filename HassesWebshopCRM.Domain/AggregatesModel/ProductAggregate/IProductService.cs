using System.Collections.Generic;
using System.Threading.Tasks;

namespace HassesWebshopCRM.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> AddAsync(Product customer);
        Task<Product> GetByIdAsync(int Id);
        void Update(Product product);
        void Delete(Product product);
    }
}
