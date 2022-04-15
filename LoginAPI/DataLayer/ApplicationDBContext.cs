using System;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<RoleMapping>().HasKey(rm => new { rm.RoleId, rm.UserId});

            builder.Entity<RoleMapping>().HasOne(rm => rm.Employee).WithMany(e=> e.RoleMapping).HasForeignKey(bc => bc.UserId);

            builder.Entity<RoleMapping>().HasOne(rm => rm.Roles).WithMany(r => r.RoleMapping).HasForeignKey(bc => bc.RoleId);

            base.OnModelCreating(builder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RoleMapping> RoleMapping { get; set; }
    }
}
