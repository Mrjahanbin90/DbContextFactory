using DbContextFactory.Domain;
using DbContextFactory.UOW;
using Microsoft.AspNetCore.Mvc;

namespace DbContextFactory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet()]
        public async Task<IActionResult> GetCompany()
        {
            var Company = await _unitOfWork.ProductCompany.GetAllAsync();
            if (Company == null)
            {
                return NotFound();
            }

            return Ok(Company);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCompany(int id)
        {
            var ProductCompany = await _unitOfWork.ProductCompany.GetByIdAsync(id);
            if (ProductCompany == null)
            {
                return NotFound();
            }

            return Ok(ProductCompany);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductCompany(ProductCompanyViewModel ProductCompany)
        {
            await _unitOfWork.ProductCompany.AddAsync(new() { CompanyId = ProductCompany.CompanyId, ProductId = ProductCompany.ProductId });
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductCompany), new { id = ProductCompany.Id }, ProductCompany);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCompany(int id, ProductCompany ProductCompany)
        {
            if (id != ProductCompany.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ProductCompany.Update(ProductCompany);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCompany(int id)
        {
            var ProductCompany = await _unitOfWork.ProductCompany.GetByIdAsync(id);
            if (ProductCompany == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductCompany.Remove(ProductCompany);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }

}
