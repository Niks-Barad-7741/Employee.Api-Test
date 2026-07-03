using Microsoft.EntityFrameworkCore;
using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace Employee.Infrastructure.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }


        public DbSet<Employe> Employee { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public DbSet<Permissions> Permission { get; set; }
        public DbSet<EmployeePermissions> EmployeePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
                );

            modelBuilder.Entity<EmployeeRoles>(entity => 
            {
                entity.HasOne(sr => sr.Employe)
                .WithMany(sr => sr.EmployeeRoles)
                .HasForeignKey(sr => sr.EmployeeId);

                entity.HasOne(sr => sr.Role)
                .WithMany(sr => sr.EmployeeRoles)
                .HasForeignKey(sr => sr.RoleId);
            });

            modelBuilder.Entity<Permissions>().HasData(
                new Permissions { Id = 1, PermissionName = "Create" },
                new Permissions { Id = 2, PermissionName = "Read" },
                new Permissions { Id = 3, PermissionName = "Update" },
                new Permissions { Id = 4, PermissionName = "Delete" }
                );
        }
    }

}
