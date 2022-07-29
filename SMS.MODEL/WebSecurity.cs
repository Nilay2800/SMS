using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SMS.Model
{
    public partial class WebSecurity : DbContext
    {
        public WebSecurity()
            : base("name=StudentEntites")
        {
        }

        //public virtual DbSet<webpages_Membership> webpages_Membership { get; set; }
        //public virtual DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        //public virtual DbSet<webpages_Roles> webpages_Roles { get; set; }
        //public virtual DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<webpages_Roles>()
        //        .HasMany(e => e.webpages_UsersInRoles)
        //        .WithRequired(e => e.webpages_Roles)
        //        .WillCascadeOnDelete(false);
        //}
    }
}
