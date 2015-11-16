namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("cabspotdb.vehiculo")]
    public partial class vehiculos
    {
        [Key]
        public int idVehiculo { get; set; }

        public int? idTaxista { get; set; }

        [Required]
        [StringLength(50)]
        public string chasis { get; set; }

        [Required]
        [StringLength(10)]
        public string placa { get; set; }

        [Required]
        [StringLength(20)]
        public string marca { get; set; }

        [Required]
        [StringLength(20)]
        public string modelo { get; set; }

        [StringLength(5)]
        public string serie { get; set; }

        [Required]
        [StringLength(5)]
        public string anio { get; set; }

        [Required]
        [StringLength(10)]
        public string color { get; set; }

        [Required]
        [StringLength(5)]
        public string unidad { get; set; }

        public int? idTipoVehiculo { get; set; }

        public int? idEstadoVehiculo { get; set; }

        public int? idCondicionVehiculo { get; set; }

        public int cantidadAsientos { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }
        
        [ForeignKey("empleados")]
        public int? registradoPor { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaUltimaModificacion { get; set; }

        public int? modificadoPor { get; set; }

        public virtual condicionvehiculos condicionvehiculos { get; set; }

        public virtual empleados empleados { get; set; }
        
        public virtual estadovehiculos estadovehiculos { get; set; }

        public virtual taxistas taxistas { get; set; }

        public virtual tipovehiculos tipovehiculos { get; set; }

        //Valores no mapeados
        [NotMapped]
        public int condicionSeleccionada { get; set; }
        [NotMapped]
        public int estadoSeleccionado { get; set; }
        [NotMapped]
        public int tipoSeleccionado { get; set; }

        [NotMapped]
        public SelectList listaCondicion { get; set; }
        [NotMapped]
        public SelectList listaEstado { get; set; }
        [NotMapped]
        public SelectList listaTipo { get; set; }
    }
}
