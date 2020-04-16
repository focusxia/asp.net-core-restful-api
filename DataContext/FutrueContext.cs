using DotnetRestFulWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi
{
    public class FutrueContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRoleRelationship> UserRoleRelationship { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermissionRelationship> RolePermissionRelationship { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FutureDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoleRelationship>()
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<UserRoleRelationship>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoleRelationship)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserRoleRelationship>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoleRelationship)
                .HasForeignKey(x => x.RoleId);


            modelBuilder.Entity<RolePermissionRelationship>()
                .HasKey(x => new { x.RoleId, x.PermissionId });

            modelBuilder.Entity<RolePermissionRelationship>()
                .HasOne(x => x.Role)
                .WithMany(x => x.RolePermissionRelationship)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<RolePermissionRelationship>()
                .HasOne(x => x.Permission)
                .WithMany(x => x.RolePermissionRelationship)
                .HasForeignKey(x => x.PermissionId);

        }
    }
}
