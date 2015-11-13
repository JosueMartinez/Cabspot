namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
using System.Web.Mvc;

    [Table("cabspotdb.empleados")]
    public partial class empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleados()
        {
        }

        [Key]
        public int idEmpleado { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        public int? registradoPor { get; set; }

        public int idEstadoEmpleado { get; set; }

        public int idBase { get; set; }

        public int idRol { get; set; }

        //agregado luego
        public int idPersona { get; set; }

        [Required]
        [StringLength(25)]
        public string usuario { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string contrasena { get; set; }

        public virtual bases bases { get; set; }

        public virtual estadoempleados estadoempleados { get; set; }

        public virtual roles roles { get; set; }
        
        public virtual personas personas { get; set; }

        //not mapped-----------------------------------------------------
        [NotMapped]
        public SelectList listaBases { get; set; }
        [NotMapped]
        public string baseSeleccionada { get; set; }

        [NotMapped]
        public SelectList listaRoles { get; set; }
        [NotMapped]
        public string rolSeleccionado { get; set; }

        [NotMapped]
        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("contrasena")]
        public string confirmarContrasena { get; set; }

    }
}
