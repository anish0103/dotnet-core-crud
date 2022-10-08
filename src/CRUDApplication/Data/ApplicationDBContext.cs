using CRUDApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Customer> CustomerList { get; set; }
    }
}
