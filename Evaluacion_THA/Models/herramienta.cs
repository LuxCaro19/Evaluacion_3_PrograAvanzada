namespace Evaluacion_THA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("herramienta")]
    public partial class herramienta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public herramienta()
        {
            asignar = new HashSet<asignar>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "el largo debe estar entre 2 y 10")]
        [RegularExpression(@"^[A-Za-z ]+$",
            ErrorMessage = "El nombre solo debe contener letras")]
        public string nombre { get; set; }

        [Required]
        [StringLength(90, MinimumLength = 2, ErrorMessage = "el largo debe estar entre 2 y 90")]
        [RegularExpression(@"^[0-9A-Za-z ]+$",
            ErrorMessage = "El nombre no puede contener simbolos")]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asignar> asignar { get; set; }
    }
}
