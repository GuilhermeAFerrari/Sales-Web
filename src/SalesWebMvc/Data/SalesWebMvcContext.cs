using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departament> Departament { get; set; } = default!;

        public DbSet<Seller> Seller { get; set; } = default!;

        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Seller>(e =>
        //    {
        //        e.HasKey(of => of.Id);
        //        e.Property(of => of.Name).IsRequired();
        //        e.Property(of => of.Email).IsRequired();
        //        e.Property(of => of.BirthDate).IsRequired();
        //        e.Property(of => of.BaseSalary).IsRequired();
        //        e.Property(of => of.Departament).IsRequired(false);
        //    });
        //}
    }
}
