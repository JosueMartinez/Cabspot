namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cabspotdb.taxistas")]
    public partial class taxistas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taxistas()
        {
            carreras = new HashSet<carreras>();
            vehiculos = new HashSet<vehiculos>();
        }

        [Key]
        public int idTaxista { get; set; }

        public int? idPersona { get; set; }

        [Required]
        [StringLength(10)]
        public string codigoTaxita { get; set; }

        public int? idEstadoDisponibilidad { get; set; }

        public int? idBase { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        public int? registradoPor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<carreras> carreras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehiculos> vehiculos { get; set; }
    }
}
