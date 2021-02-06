using HassesWebshopCRM.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HassesWebshopCRM.Domain.AggregatesModel.ProductAggregate
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> porductRepository)
        {
            _productRepository = porductRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> AddAsync(Product customer)
        {
            return await _productRepository.AddAsync(customer);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task  UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task  DeleteAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);
        }

        
    }
}
