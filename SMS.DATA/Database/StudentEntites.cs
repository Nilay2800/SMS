using SMS.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace SMS.Data.Database
{
    public class StudentEntites : DbContext
    {
        // Your context has been configured to use a 'StudentEntites' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SMS.Data.Database.StudentEntites' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentEntites' 
        // connection string in the application configuration file.
        public StudentEntites()
            : base("name=StudentEntites")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Annoucement> annoucements { get; set; }
        public DbSet<Signups> signups { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<FormModel> formModel { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}