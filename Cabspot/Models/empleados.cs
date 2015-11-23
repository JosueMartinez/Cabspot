namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
using System.Web.Mvc;

    [Table("empleados")]
    public partial class empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleados()
        {
        }

        [Key]
        [Column("idEmpleado")]
        public int idEmpleado { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        [Display(Name="Registrado Por")]
        public int? registradoPor { get; set; }

        public int idEstadoEmpleado { get; set; }

        public int idBase { get; set; }

        public int idRol { get; set; }

        //agregado luego
        public int idPersona { get; set; }

        [Required(ErrorMessage="Debe elegir su nombre de usuario")]
        [StringLength(25)]
        [Display(Name="Usuario")]
        public string usuario { get; set; }

        [Required(ErrorMessage="¿Cuál va a ser su contraseña?")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Contrasena")]
        public string contrasena { get; set; }

        public virtual bases bases { get; set; }

        public virtual estadoempleados estadoempleados { get; set; }

        public virtual roles roles { get; set; }
        
        public virtual personas personas { get; set; }

        //not mapped-----------------------------------------------------
        [NotMapped]
        public SelectList listaBases { get; set; }
        [NotMapped]
        [Display(Name="Base")]
        [Required]
        public string baseSeleccionada { get; set; }

        [NotMapped]
        public SelectList listaRoles { get; set; }
        [NotMapped]
        [Display(Name="Rol")]
        [Required(ErrorMessage = "¿Cuál será el rol del empleado?")]
        public string rolSeleccionado { get; set; }

        [NotMapped]
        [Required(ErrorMessage="Confirme su contraseña")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("contrasena", ErrorMessage="Las contraseñas no coinciden")]
        [Display(Name = "Confirmar Contraseña")]
        public string confirmarContrasena { get; set; }

    }
}
