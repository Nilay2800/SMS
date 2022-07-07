using SMS.Data.Database;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class SMSContext:DbContext
    {
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Annoucement> annoucements { get; set; }
        public DbSet<Signup> signups { get; set; }
        public DbSet<Student> students { get; set; }

        public System.Data.Entity.DbSet<SMS.Model.SignupModel> SignupModels { get; set; }
    }
}
