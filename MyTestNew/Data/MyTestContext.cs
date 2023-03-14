using Microsoft.EntityFrameworkCore;
using MyTestNew.Models;
namespace MyTestNew.Data
{
    public class MyTestContext : DbContext
    {
        public MyTestContext(DbContextOptions<MyTestContext> Options) : base(Options)
        {

        }
        public DbSet<Emp> emps { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<WorkM> workMs { get; set; }
    }
}
