namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cabspotdb.contactos")]
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

        [StringLength(10)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "El formato no es válido")]
        [Phone]
        public string telefonoMovil { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string telefonoResidencial { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string telefonoTrabajo { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string fax { get; set; }

        [Column(TypeName = "text")]
        [DataType(DataType.EmailAddress)]
        [StringLength(65535)]
        [EmailAddress]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string emailAlternativo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        [DataType(DataType.Url)]
        [Url]
        public string paginaWeb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bases> bases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personas> personas { get; set; }
    }
}
