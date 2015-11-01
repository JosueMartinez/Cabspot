namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cabspotdb.clientes")]
    public partial class clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            carreras = new HashSet<carreras>();
            sugerencias = new HashSet<sugerencias>();
        }

        [Key]
        public int idCliente { get; set; }

        public int? idPersona { get; set; }

        [StringLength(15)]
        public string nombreUsuario { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<carreras> carreras { get; set; }

        public virtual personas personas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sugerencias> sugerencias { get; set; }
    }
}
