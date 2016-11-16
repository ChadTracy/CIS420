using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using AHA_Web.Models;
using System;

namespace AHA_Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName {get; set; }
        public string LastName { get; set; }
        public string AccountType { get; set; } 
        public DateTime BirthDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //This will create database if one doesn't exist.

            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());

            //This will drop and re-create the database if model changes.

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
             
             base.OnModelCreating(modelBuilder);
         }
        
         public DbSet<Event> Events { get; set; }
         public DbSet<Grant> Grants { get; set; }
         public DbSet<Grantor> Grantors { get; set; }
  
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramEnrollment> ProgramEnrollment { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

        public System.Data.Entity.DbSet<AHA_Web.Models.MailChimp> MailChimps { get; set; }

    }
}