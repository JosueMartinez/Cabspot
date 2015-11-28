namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("vehiculo")]
    public partial class vehiculos
    {
        [Key]
        public int idVehiculo { get; set; }

        public int? idTaxista { get; set; }

        [Required(ErrorMessage = "�Cu�l es el n�mero de chasis?")]
        [StringLength(50)]
        [Display(Name = "Chasis")]
        public string chasis { get; set; }

        [Required(ErrorMessage = "�Cu�l es la placa?")]
        [StringLength(10)]
        [Display(Name = "Placa")]
        public string placa { get; set; }

        [Required(ErrorMessage = "�Cu�l es la marca?")]
        [StringLength(20)]
        [Display(Name = "Marca")]
        public string marca { get; set; }

        [Required(ErrorMessage = "�Cu�l es el modelo?")]
        [StringLength(20)]
        [Display(Name = "Modelo")]
        public string modelo { get; set; }

        [StringLength(5)]
        [Display(Name = "Serie")]
        public string serie { get; set; }

        [Required(ErrorMessage = "�De qu� a�o?")]
        [StringLength(5)]
        [Display(Name = "A�o")]
        public string anio { get; set; }

        [Required(ErrorMessage = "�De qu� color?")]
        [StringLength(10)]
        [Display(Name = "Color")]
        public string color { get; set; }

        [Required(ErrorMessage = "�C�mo se identifica la �nidad?")]
        [StringLength(5)]
        [Display(Name = "Unidad")]
        public string unidad { get; set; }

        [Display(Name = "Tipo")]
        public int? idTipoVehiculo { get; set; }

        [Display(Name = "Estado")]
        public int? idEstadoVehiculo { get; set; }

        [Display(Name = "Condici�n")]
        public int? idCondicionVehiculo { get; set; }

        [Display(Name = "Cantidad Asientos")]
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
        [Required(ErrorMessage = "�En qu� condici�n est�?")]
        [Display(Name = "Condici�n")]
        public int condicionSeleccionada { get; set; }

        [NotMapped]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "�En qu� estado est�?")]
        public int estadoSeleccionado { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "�Qu� tipo de veh�culo es?")]
        [Display(Name = "Tipo")]
        public int tipoSeleccionado { get; set; }

        [NotMapped]
        public SelectList listaCondicion { get; set; }
        [NotMapped]
        public SelectList listaEstado { get; set; }
        [NotMapped]
        public SelectList listaTipo { get; set; }
    }
}
