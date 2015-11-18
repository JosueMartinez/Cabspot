namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bases")]
    public partial class bases
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bases()
        {
            empleados = new HashSet<empleados>();
        }

        [Key]
        public int idBase { get; set; }

        [Required]
        [StringLength(50)]
        public string nombreBase { get; set; }

        public int idDireccion { get; set; }

        public int idContacto { get; set; }

        public virtual direcciones direcciones { get; set; }

        public virtual contactos contactos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados> empleados { get; set; }
    }
}
