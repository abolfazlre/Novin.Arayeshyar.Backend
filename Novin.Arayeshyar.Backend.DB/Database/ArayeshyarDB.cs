using Microsoft.EntityFrameworkCore;
using Novin.Arayeshyar.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Arayeshyar.Backend.DB.Database
{
    public class ArayeshyarDB : DbContext
    {
        public DbSet<SystemAdmin> SystemAdmins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BarberShopOwner> BarberShopOwners { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Dermatologist> Dermatologists { get; set; }

        public ArayeshyarDB(DbContextOptions<ArayeshyarDB> options)
            : base( options )
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Customer>()
                .HasKey(m => m.MobileNumber);
            modelBuilder
                .Entity<Barber>()
                .HasKey(m => m.MobileNumber);
            modelBuilder
                .Entity<BarberShopOwner>()
                .HasKey(m => m.MobileNumber);
            modelBuilder
                .Entity<SystemAdmin>()
                .HasKey(s => s.Username);
            modelBuilder
                .Entity<Dermatologist>()
                .HasKey(m => m.MobileNumber);
        }
    }
}
