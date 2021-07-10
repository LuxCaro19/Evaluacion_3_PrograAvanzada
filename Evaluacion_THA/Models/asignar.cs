namespace Evaluacion_THA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("asignar")]
    public partial class asignar
    {
        public int id { get; set; }

        public DateTime fechaEnt { get; set; }

        public DateTime fechaDev { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }

        public int idHerramienta { get; set; }

        public int idTrabajador { get; set; }

        public virtual herramienta herramienta { get; set; }

        public virtual trabajador trabajador { get; set; }
    }
}
