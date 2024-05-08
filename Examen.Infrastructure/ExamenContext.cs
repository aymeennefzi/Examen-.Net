
using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class ExamenContext:DbContext
    {
        public DbSet<Banque> Banques { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<DAB> DABs { get; set; }
        public DbSet<TransacationTransfert> TransacationTransferts { get; set; }
        public DbSet<TransactionRetarit> TransactionRetarits { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies(); 

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog= DabAymenNefzi;
                       Integrated Security=true;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasDiscriminator<char>("Descriminator")
                .HasValue<Transaction>('H')
                .HasValue<TransacationTransfert>('T')
                .HasValue<TransactionRetarit>('R');

            modelBuilder.Entity<Transaction>()
            .HasKey(t => new { t.NumeroCompteFk, t.DABFk, t.Date });

            modelBuilder.Entity<Transaction>()
                .HasOne(c => c.Compte)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.NumeroCompteFk);

            modelBuilder.Entity<Transaction>()
           .HasOne(t => t.DAB)
           .WithMany(d => d.Transactions)
           .HasForeignKey(s => s.DABFk);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            
        }
    }
}
