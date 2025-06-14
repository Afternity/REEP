using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REEP.Identity.Data.Configurations;
using REEP.Identity.Models.DomainModels;


namespace REEP.Identity.Data.DbContexts
{
    public class ReepAuthDbContext : IdentityDbContext<AppUser>
    {
        private readonly DbContextOptions<ReepAuthDbContext> _options;

        public ReepAuthDbContext(DbContextOptions<ReepAuthDbContext> options)
            : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(entity => entity.ToTable(name: "Users"));
            modelBuilder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
                entity.ToTable(name: "UserRoles"));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
                entity.ToTable(name: "UserClaims"));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
                entity.ToTable(name: "UserLogins"));
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
                entity.ToTable(name: "UserTokens"));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
                entity.ToTable(name: "RoleClaims"));

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());    
        }
    }
}
