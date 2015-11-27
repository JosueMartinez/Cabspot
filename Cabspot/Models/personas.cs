namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using DevelopersDo.DataAnnotations;
    using Microsoft.SqlServer.Server;

    [Table("personas")]
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

        [Required(ErrorMessage = "�Cu�l es su c�dula?")]
        [StringLength(15)]
        [Cedula(ErrorMessage = "La c�dula no es v�lida")]
        [Display(Name="C�dula")]
        [DisplayFormat(DataFormatString = "{0:000-0000000-0}", ApplyFormatInEditMode = true)]
        public string identificacion { get; set; }

        [Required(ErrorMessage = "�C�mo se llama?")]
        [StringLength(30)]
        [Display(Name = "Nombre(s)")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "�Cu�les son sus apellidos?")]
        [StringLength(50)]
        [Display(Name = "Apellido(s)")]
        public string apellidos { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "�Cu�ndo naci�?")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaNacimiento { get; set; }

        [Column(TypeName = "char")]
        [Required(ErrorMessage = "Debe elegir un g�nero")]
        [StringLength(1)]
        [Display(Name = "Genero")]
        public string sexo { get; set; }

        [Required(ErrorMessage = "Debe elegir una foto de perfil")]
        [StringLength(255)]
        public string foto { get; set; }

        [Required(ErrorMessage = "�Cu�l es su nacionalidad?")]
        [StringLength(50)]
        [Display(Name = "Nacionalidad")]
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
