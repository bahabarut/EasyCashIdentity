using EasyCashIdentityEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityDataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-K9RNB1L;initial catalog=EasyCash;integrated security=true;");
        }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.SenderCustomer)
                .WithMany(y => y.SenderProcess)
                .HasForeignKey(z => z.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.ReceiverCustomer)
                .WithMany(y => y.ReceivePropcess)
                .HasForeignKey(z => z.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(builder);
        }
    }
}
