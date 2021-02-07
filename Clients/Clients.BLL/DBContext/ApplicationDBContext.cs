using Clients.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clients.DAL.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        public DbSet<ClientEntity> Clients { get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>().ToTable("Clients");
            modelBuilder.Entity<ClientEntity>().Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<ClientEntity>().Property(x => x.Name).HasColumnName("Name");
            modelBuilder.Entity<ClientEntity>().Property(x => x.BirthDate).HasColumnName("BirthDate");
            modelBuilder.Entity<ClientEntity>().Property(x => x.Address).HasColumnName("Address");
            modelBuilder.Entity<ClientEntity>().Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
            modelBuilder.Entity<ClientEntity>().Property(x => x.SocialNumber).HasColumnName("SocialNumber");

            base.OnModelCreating(modelBuilder);
        }

    }
}
