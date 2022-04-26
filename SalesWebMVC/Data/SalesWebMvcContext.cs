using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("SEQ_Department")
                    .StartsAt(5)
                    .IncrementsBy(1);

            modelBuilder.Entity<Department>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("nextval('\"SEQ_Department\"')");

            modelBuilder.HasSequence<int>("SEQ_Seller")
                    .StartsAt(7)
                    .IncrementsBy(1);

            modelBuilder.Entity<Seller>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("nextval('\"SEQ_Seller\"')");

            modelBuilder.HasSequence<int>("SEQ_SaleRecord")
                    .StartsAt(7)
                    .IncrementsBy(1);

            modelBuilder.Entity<SalesRecord>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("nextval('\"SEQ_SaleRecord\"')");

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
        .SelectMany(t => t.GetForeignKeys())
        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.NoAction;

        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
