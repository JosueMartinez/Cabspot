namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cabspotdb.empleados")]
    public partial class empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleados()
        {
            empleados1 = new HashSet<empleados>();
            vehiculos = new HashSet<vehiculos>();
            vehiculos1 = new HashSet<vehiculos>();
        }

        [Key]
        public int idEmpleado { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        public int? registradoPor { get; set; }

        public int? idEstadoEmpleado { get; set; }

        public int? idBase { get; set; }

        public int? idRol { get; set; }

        [Required]
        [StringLength(25)]
        public string usuario { get; set; }

        [Required]
        [StringLength(20)]
        public string contrasena { get; set; }

        public virtual bases bases { get; set; }

        public virtual estadoempleados estadoempleados { get; set; }

        public virtual roles roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados> empleados1 { get; set; }

        public virtual empleados empleados2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehiculos> vehiculos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehiculos> vehiculos1 { get; set; }
    }
}
