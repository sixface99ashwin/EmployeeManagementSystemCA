using EmployeeManagementSystemCA.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemCA.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<PaymentRule> PaymentRules { get; set; }
        public DbSet<RequestLeave> RequestLeaves { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
