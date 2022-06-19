using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasDefaultSchema("dbo");

            //modelBuilder.Entity<ApplicationUser>().ToTable("User", "dbo");
            //modelBuilder.Entity<ApplicationUser>().Property(p => p.Id).HasColumnName("User_ID");
            //modelBuilder.Entity<ApplicationUser>().Property(p => p.UserName).HasColumnName("User_UserName");
            //modelBuilder.Entity<ApplicationUser>().Property(p => p.Email).HasColumnName("User_Email");
            //modelBuilder.Entity<ApplicationUser>().Property(p => p.PasswordHash).HasColumnName("User_Password");
        }
    }
}