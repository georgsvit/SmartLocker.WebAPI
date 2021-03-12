using Microsoft.EntityFrameworkCore;
using SmartLocker.WebAPI.Domain;
using SmartLocker.WebAPI.Domain.RegisterNotes;

namespace SmartLocker.WebAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ServiceBook> ServiceBooks { get; set; }
        public DbSet<Locker> Lockers { get; set; }
        public DbSet<AccountingRegisterNote> AccountingNotes { get; set; }
        public DbSet<ServiceRegisterNote> ServiceNotes { get; set; }
        public DbSet<ViolationRegisterNote> ViolationNotes { get; set; }
        public DbSet<QueueRegisterNote> QueueNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccountingRegisterNote>().ToTable("AccountingRegister");
            modelBuilder.Entity<ServiceRegisterNote>().ToTable("ServiceRegister");
            modelBuilder.Entity<ViolationRegisterNote>().ToTable("ViolationRegister");
            modelBuilder.Entity<QueueRegisterNote>().ToTable("QueueRegister");

            modelBuilder.Entity<Tool>()
                .HasOne(t => t.ServiceBook)
                .WithOne(sb => sb.Tool)
                .HasForeignKey<ServiceBook>(sb => sb.ToolId);
        }
    }
}
