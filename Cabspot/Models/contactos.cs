namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contactos")]
    public partial class contactos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public contactos()
        {
            bases = new HashSet<bases>();
            personas = new HashSet<personas>();
        }

        [Key]
        public int idContacto { get; set; }

        [StringLength(12)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "El formato no es válido")]
        [Required(ErrorMessage="¿Cuál es el número de móvil?")]
        [Phone]
        [Display(Name = "Celular")]
        public string telefonoMovil { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Casa")]
        public string telefonoResidencial { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Trabajo")]
        public string telefonoTrabajo { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Fax")]
        public string fax { get; set; }

        [Column(TypeName = "text")]
        [DataType(DataType.EmailAddress)]
        [StringLength(65535)]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "E-Mail Alternativo")]
        public string emailAlternativo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        [DataType(DataType.Url)]
        [Url]
        [Display(Name = "Página Web")]
        public string paginaWeb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bases> bases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personas> personas { get; set; }
    }
}
