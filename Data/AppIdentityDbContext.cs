using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Inspecoes.Models;

namespace Inspecoes.Data
{
    public class AppIdentityDbContext : IdentityDbContext
        //<CustomUser, CustomRole, string, CustomUserClaim, CustomUserRole,
        //CustomUserLogin, CustomRoleClaim, CustomUserToken>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        /*
                protected override void OnModelCreating(ModelBuilder builder)
                {
                    base.OnModelCreating(builder);
                    //modelBuilder.Entity<ApplicationUser>().ToTable("Core_User");
                    builder.Entity<CustomUser>().HasMany(p => p.UserRoles).WithOne().HasForeignKey(p => p.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                    builder.Entity<CustomRole>().HasMany(r => r.UserRoles).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

                    builder.Entity<CustomUser>().HasMany(e => e.Claims).WithOne().HasForeignKey(e => e.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                    builder.Entity<CustomRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

                    builder.Entity<CustomUserRole>().HasOne(r => r.User).WithMany(u => u.UserRoles).HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                    builder.Entity<CustomUserRole>().HasOne(r => r.Role).WithMany(u => u.UserRoles).HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.NoAction);

                    builder.Entity<CustomUser>().HasQueryFilter(u => u.Deleted == false);
                    builder.Entity<CustomRole>().HasQueryFilter(u => u.Deleted == false);
                }
        */
    }

    /*
            public class CustomUser : IdentityUser<string>
            {
                public string Name { get; set; }
                public bool Active { get; set; }
                public bool Deleted { get; set; }
                public virtual ICollection<CustomUserRole> UserRoles { get; set; }
                public virtual ICollection<CustomUserClaim> Claims { get; set; }
            }
            public class CustomRole : IdentityRole<string>
            {
                public bool Active { get; set; }
                public bool Deleted { get; set; }
                public virtual ICollection<CustomUserRole> UserRoles { get; set; }
                public virtual ICollection<CustomRoleClaim> Claims { get; set; }
            }
            public class CustomUserRole : IdentityUserRole<string>
            {
                //public override string RoleId { get; set; }
                public virtual CustomRole Role { get; set; }
                //public override string UserId { get; set; }
                public virtual CustomUser User { get; set; }
            }
            public class CustomUserLogin : IdentityUserLogin<string> { }
            public class CustomUserToken : IdentityUserToken<string> { }

            public class CustomUserClaim : IdentityUserClaim<string> { }
            public class CustomRoleClaim : IdentityRoleClaim<string> { }

            */
}