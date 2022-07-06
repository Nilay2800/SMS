using SMS.Model;
using System;
using System.Data.Entity;
using System.Linq;
using SMS.Data;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SMS.Data
{
    public class StudentEntites : DbContext
    {
        public StudentEntites()
            : base("name=StudentEntites")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Student> students { get; set; }
        public DbSet<FormModel> formModel { get; set; }
     }

    
}