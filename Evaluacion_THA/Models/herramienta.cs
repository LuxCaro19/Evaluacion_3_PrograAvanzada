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
        [StringLength(10)]
        public string nombre { get; set; }

        [Required]
        [StringLength(90)]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asignar> asignar { get; set; }
    }
}
