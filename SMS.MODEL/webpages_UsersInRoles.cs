namespace SMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class webpages_UsersInRoles
    {
        [Key]
        public int Id { get; set; }
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }
        //public int Id { get; set; }

        //public virtual webpages_Roles webpages_Roles { get; set; }
    }
}
