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

        [Required(ErrorMessage = "campo es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "no tiene el formato correcto")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaEnt { get; set; }

        [Required(ErrorMessage = "campo es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "no tiene el formato correcto")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaDev { get; set; }

        [Required(ErrorMessage = "campo es obligatorio")]
        [StringLength(100)]
        public string descripcion { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public int idHerramienta { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public int idTrabajador { get; set; }

        public virtual herramienta herramienta { get; set; }

        public virtual trabajador trabajador { get; set; }
    }
}
