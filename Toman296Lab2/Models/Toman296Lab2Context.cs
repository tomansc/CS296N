using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Toman296Lab2.Models
{
    public class Toman296Lab2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Toman296Lab2Context() : base("name=Toman296Lab2Context")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public System.Data.Entity.DbSet<Toman296Lab2.Models.ForumView> ForumViews { get; set; }

        public System.Data.Entity.DbSet<Toman296Lab2.Models.Message> Message { get; set; }

        public System.Data.Entity.DbSet<Toman296Lab2.Models.Member> Member { get; set; }
        public System.Data.Entity.DbSet<Toman296Lab2.Models.MessageView> MessageView { get; set; }

    
    }
}
