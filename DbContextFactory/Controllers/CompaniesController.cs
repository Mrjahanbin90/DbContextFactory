using DbContextFactory.Domain;
using DbContextFactory.UOW;
using Microsoft.AspNetCore.Mvc;

namespace DbContextFactory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet()]
        public async Task<IActionResult> GetCompany()
        {
            var Company = await _unitOfWork.Company.GetAllAsync();
            if (Company == null)
            {
                return NotFound();
            }

            return Ok(Company);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var Company = await _unitOfWork.Company.GetByIdAsync(id);
            if (Company == null)
            {
                return NotFound();
            }

            return Ok(Company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyViewModel Company)
        {
            await _unitOfWork.Company.AddAsync(new() { Name = Company.Name });
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompany), new { id = Company.Id }, Company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, Company Company)
        {
            if (id != Company.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Company.Update(Company);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var Company = await _unitOfWork.Company.GetByIdAsync(id);
            if (Company == null)
            {
                return NotFound();
            }

            _unitOfWork.Company.Remove(Company);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }

}
