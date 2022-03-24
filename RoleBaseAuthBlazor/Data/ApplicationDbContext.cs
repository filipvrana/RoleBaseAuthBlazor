using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RoleBaseAuthBlazor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<Game> Games { get; set; }
        //public DbSet<PracticeAttendance> PracticeAttendances { get; set; }
        public DbSet<Moneyy> Money { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Practice>()
                .HasMany(ub => ub.BlazorUsers)
                .WithMany(au => au.Practices)
                .UsingEntity(au => au.ToTable("BlazorUserPractice"));


            modelBuilder.Entity<BlazorUser>()
                .HasMany(ub => ub.Practices)
                .WithMany(c => c.BlazorUsers)
                .UsingEntity(au => au.ToTable("BlazorUserPractice"));

            



        }
    }
}