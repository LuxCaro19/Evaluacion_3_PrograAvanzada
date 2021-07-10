using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Evaluacion_THA.Models
{
    public partial class ModelData : DbContext
    {
        public ModelData()
            : base("name=db_eva")
        {
        }

        public virtual DbSet<asignar> asignar { get; set; }
        public virtual DbSet<herramienta> herramienta { get; set; }
        public virtual DbSet<trabajador> trabajador { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<herramienta>()
                .HasMany(e => e.asignar)
                .WithRequired(e => e.herramienta)
                .HasForeignKey(e => e.idHerramienta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trabajador>()
                .HasMany(e => e.asignar)
                .WithRequired(e => e.trabajador)
                .HasForeignKey(e => e.idTrabajador)
                .WillCascadeOnDelete(false);
        }
    }
}
