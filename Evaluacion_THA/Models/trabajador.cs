namespace Evaluacion_THA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trabajador")]
    public partial class trabajador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trabajador()
        {
            asignar = new HashSet<asignar>();
        }

        public int id { get; set; }


        [Required(ErrorMessage = "campo es obligatorio")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "el largo debe estar entre 2 y 10")]
        public string nombre { get; set; }


        [Required(ErrorMessage = "campo es obligatorio")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "el largo debe estar entre 2 y 15")]
        public string apellido { get; set; }


        [Required(ErrorMessage = "campo es obligatorio")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "el largo debe estar entre 1 y 30")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        public string correo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asignar> asignar { get; set; }
    }
}
