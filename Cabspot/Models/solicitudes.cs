namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cabspotdb.solicitudes")]
    public partial class solicitudes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public solicitudes()
        {
            carreras = new HashSet<carreras>();
        }

        [Key]
        public int idSolicitud { get; set; }

        public int? solicitadoPor { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaSolicitud { get; set; }

        [Required]
        [StringLength(30)]
        public string longitudOrigen { get; set; }

        [Required]
        [StringLength(30)]
        public string latitudOrigen { get; set; }

        [Required]
        [StringLength(30)]
        public string longitudDestino { get; set; }

        [Required]
        [StringLength(30)]
        public string latitudDestino { get; set; }

        public int? idViaSolicitud { get; set; }

        public int? idMetodoPago { get; set; }

        public int? idEstadoSolicitud { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<carreras> carreras { get; set; }

        public virtual clientes clientes { get; set; }

        public virtual estadosolicitud estadosolicitud { get; set; }

        public virtual metodopago metodopago { get; set; }

        public virtual viasolicitud viasolicitud { get; set; }
    }
}
