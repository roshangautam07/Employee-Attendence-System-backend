using System.IO;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dotnet.DataAccess
{
    public class EmployeeDbContext:DbContext
    {

        public EmployeeDbContext(DbContextOptions _db):base(_db)
        {
            
        }
        public  DbSet<Employee> employee { get; set; }
        public  DbSet<Attendance> attendance { get; set; }
        public  DbSet<Users> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                Entity<Employee>()
                .ToTable("tbl_employee");
            modelBuilder.
                Entity<Attendance>()
                .ToTable("tbl_attendance");

           modelBuilder.
               Entity<Users>()
               .ToTable("tbl_users");
        }
        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            //reading from json object
            // var builder = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json");
            // var config = builder.Build();
            // optionsBuilder.UseSqlServer(config["ConnectionString:DefaultConnection"]);
          //  optionsBuilder.UseSqlServer("server=localhost;user=SA;password=2419969@Rr;database=Customer");
        //}
    }
}
//for migration
// dotnet tool install --global dotnet-ef
