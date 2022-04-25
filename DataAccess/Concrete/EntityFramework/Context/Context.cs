using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MEHDI\GULER;Database=EReconcilationsDb;integrated security=true");
        }
        public DbSet<AccountReconcilations> AccountReconcilations { get; set; }
        public DbSet<AccountReconcilationsDetail> AccountReconcilationsDetails { get; set; }
        public DbSet<BaBsReconcilation> BaBsReconcilations { get; set; }
        public DbSet<BaBsReconcilationsDetails> BaBsReconcilationsDetails { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyAccount> CurrencyAccount { get; set; }
        public DbSet<MailParameters> MailParameters { get; set; }
        public DbSet<OperationClaims> OperationClaims { get; set; }
        public DbSet<UserCompanies> UserCompanies { get; set; }
        public DbSet<UserOperationClaims> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
