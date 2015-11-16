namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("cabspotdb.taxistas")]
    public partial class taxistas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taxistas()
        {
            carreras = new HashSet<carreras>();
            solicitudes = new HashSet<solicitudes>();
            vehiculos = new HashSet<vehiculos>();
        }

        [Key]
        public int idTaxista { get; set; }

        public int idPersona { get; set; }

        [Required]
        [StringLength(10)]
        [Column("codigoTaxista")]
        public string codigoTaxista { get; set; }

        public int? idEstadoDisponibilidad { get; set; }

        public int? idBase { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        public int? registradoPor { get; set; }

        public double? latitudActual { get; set; }

        public double? longitudActual { get; set; }

        public DateTime? ultimaActualizacionPosicion { get; set; }

        public virtual personas personas { get; set; }

        [NotMapped]
        public virtual vehiculos vehiculo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<carreras> carreras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<solicitudes> solicitudes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehiculos> vehiculos { get; set; }

        //not mapped-----------------------------------------------------
        [NotMapped]
        public SelectList listaBases { get; set; }
        [NotMapped]
        public string baseSeleccionada { get; set; }


        //[NotMapped]
        //public List<vehiculos> vehiculosAgregar {get;set;}
    }
}
