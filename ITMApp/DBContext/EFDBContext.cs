using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ITMApp.Models;

namespace ITMApp.DBContext
{
   public partial class EFDBContext : DbContext
    {
        public EFDBContext()
            : base("name=EFDBContext") { }

        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<_switch> switches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<status>()
           .Property(e => e.action)
           .IsUnicode(false);
        }
    }
}
