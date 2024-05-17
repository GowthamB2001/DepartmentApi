using Microsoft.EntityFrameworkCore;

namespace DepartmentApi.Models
{
    public class DepartmentContext:DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options) 
        { 

        }
        public DbSet<DepartmentModel> Department { get; set; }
    }
}
