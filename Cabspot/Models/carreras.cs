namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cabspotdb.carreras")]
    public partial class carreras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public carreras()
        {
            comentarios = new HashSet<comentarios>();
            encuestas = new HashSet<encuestas>();
            solicitudes = new HashSet<solicitudes>();
        }

        [Key]
        public int idCarrera { get; set; }

        public int? idTaxista { get; set; }

        public int? idEstado { get; set; }

        public DateTime fechaInicioCarrera { get; set; }

        public DateTime? fechaFinCarrera { get; set; }

        public TimeSpan? tiempoCarrera { get; set; }

        public int? idCliente { get; set; }

        public DateTime fechaSolicitud { get; set; }

        public double longitudOrigen { get; set; }

        public double longitudDestino { get; set; }

        public double latitudDestino { get; set; }

        public double latitudOrigen { get; set; }

        public int idViaSolicitud { get; set; }

        public int idMetodoPago { get; set; }

        public virtual taxistas taxistas { get; set; }

        public virtual estadocarreras estadocarreras { get; set; }

        public virtual clientes clientes { get; set; }

        public virtual viasolicitud viasolicitud { get; set; }

        public virtual metodopago metodopago { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comentarios> comentarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<encuestas> encuestas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<solicitudes> solicitudes { get; set; }
    }
}
