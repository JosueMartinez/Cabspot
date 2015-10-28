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
        public string telefonoMovil { get; set; }

        [StringLength(10)]
        public string telefonoResidencial { get; set; }

        [StringLength(10)]
        public string telefonoTrabajo { get; set; }

        [StringLength(10)]
        public string fax { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string emailAlternativo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string paginaWeb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bases> bases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personas> personas { get; set; }
    }
}
