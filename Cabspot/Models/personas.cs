namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cabspotdb.personas")]
    public partial class personas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personas()
        {
            clientes = new HashSet<clientes>();
            empleados = new HashSet<empleados>();
            taxistas = new HashSet<taxistas>();
        }

        [Key]
        public int idPersona { get; set; }

        [Required]
        [StringLength(15)]
        public string identificacion { get; set; }

        [Required]
        [StringLength(30)]
        public string nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string apellidos { get; set; }

        [Column(TypeName = "date")]
        
        public DateTime fechaNacimiento { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string sexo { get; set; }

        [Required]
        [StringLength(255)]
        public string foto { get; set; }

        [Required]
        [StringLength(50)]
        public string nacionalidad { get; set; }

        public int idDireccion { get; set; }

        public int idContacto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clientes> clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados> empleados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taxistas> taxistas { get; set; }

        public virtual contactos contactos { get; set; }

        public virtual direcciones direcciones { get; set; }
    }
}
