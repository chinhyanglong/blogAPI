using System;
using System.Linq;
using huyblog.Models.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace huyblog.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Status { get; set; }

        public int? UserTypeId { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public DateTime? LastLogin { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, ApplicationUserLogin, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private static bool _Created = false;

        public ApplicationDbContext()
        {
            if (!_Created)
            {
                _Created = true;
                Database.EnsureCreated();

            }
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<AspNetUsers>().ToTable("AspNetUsers");
        }
        public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.Entity is BaseEntity &&
                                    (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in selectedEntityList)
            {

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreateDate = DateTime.UtcNow.AddHours(1);
                }

                if (entity.State == EntityState.Modified)
                {
                    ((BaseEntity)entity.Entity).ModifyDate = DateTime.UtcNow.AddHours(1);
                }

                return base.SaveChanges();
            }

            return base.SaveChanges();

        }
    }
}
