namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("direcciones")]
    public partial class direcciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public direcciones()
        {
            bases = new HashSet<bases>();
            personas = new HashSet<personas>();
        }

        [Key]
        public int idDireccion { get; set; }

        [Required]
        [StringLength(5)]
        public string numeroPuerta { get; set; }

        [StringLength(5)]
        public string numeroEdificio { get; set; }

        [StringLength(100)]
        public string nombreEdificio { get; set; }

        [Required]
        [StringLength(255)]
        public string calle { get; set; }

        [Required]
        [StringLength(100)]
        public string ciudad { get; set; }

        public int idMunicipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bases> bases { get; set; }

        public virtual municipios municipios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personas> personas { get; set; }


        //not mapped properties-------------------------------------------------------------

        [NotMapped]
        public SelectList listaProvincias { get; set; }

        [NotMapped]
        [Required]
        public int provinciaSeleccionada { get; set; }

        [NotMapped]
        [Required]
        public int municipioSeleccionado { get; set; }

        [NotMapped]
        public SelectList listaMunicipios { get; set; }
    }
}
