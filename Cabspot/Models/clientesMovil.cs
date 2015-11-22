

namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cabspotdb.clientesMovil")]
    public partial class clientesMovil
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientesMovil()
        {
            autenticacionSms = new HashSet<autenticacionsms>();
        }

        [Key]
        public int idClienteMovil { get; set; }

        [StringLength(12)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "El formato no es válido")]
        [Required(ErrorMessage = "¿Cuál es el número de móvil?")]
        [Phone]
        [Display(Name = "Celular")]
        public string telefonoMovil { get; set; }

        [StringLength(15)]
        public string nombreUsuario { get; set; }

        [StringLength(32)]
        public string apikey { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<autenticacionsms> autenticacionSms { get; set; }
    }
}