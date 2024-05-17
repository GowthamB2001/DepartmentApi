using DepartmentApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentContext _dbContext;
        public DepartmentController(DepartmentContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartment()
        {
            if (_dbContext.Department == null)
            {
                return NotFound();
            }
            return await _dbContext.Department.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartment(int id)
        {
            if (_dbContext.Department == null)
            {
                return NotFound();
            }
            var department=await _dbContext.Department.FindAsync(id);
            if (department == null)
            { 
                 return NotFound(); 
            }
            return department;
         }
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> PostDepartment(DepartmentModel department)
        {
            _dbContext.Department.Add(department);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDepartment),new {id=department.Did},department);
        }
        [HttpPut]
        public async Task<IActionResult> PutDepartment(int id,DepartmentModel department)
        {
            if(id !=department.Did)
            {
                return BadRequest();
            }
            _dbContext.Entry(department).State= EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if(!DepartmentAvailable(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        private bool DepartmentAvailable(int id)
        {
            return (_dbContext.Department?.Any(x => x.Did == id)).GetValueOrDefault();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if(_dbContext.Department == null)
            {
                return NotFound();
            }
            var department=await _dbContext.Department.FindAsync(id);
            if(department == null)
            {
                return NotFound();
            }
            _dbContext.Department.Remove(department);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
