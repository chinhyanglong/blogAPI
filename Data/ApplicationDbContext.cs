using System;
using System.Linq;
using huyblog.Models.Base;
using huyblog.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace huyblog.Data
{
    public class ApplicationUser : IdentityUser
    {
        
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
        //DBSet
        public DbSet<Post> Posts { get; set; }
        //
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
