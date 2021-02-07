using HassesWebshopCRM.Domain.AggregatesModel.ProductAggregate;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HassesWebshopCRM.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();          
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productService.AddAsync(product);
            return Ok(product);
        }       

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Product productInputModel)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Description = productInputModel.Description;
            product.Price = productInputModel.Price;
            product.Title = productInputModel.Title;
            product.AvailableProduct = productInputModel.AvailableProduct;
            await _productService.UpdateAsync(product);
            return Ok();
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.DeleteAsync(product);
            return Ok();
        }
    }
}
