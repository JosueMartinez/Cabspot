using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Cabspot.Models
{
    [Table("cabspotdb.autenticacionsmstaxista")]
    public partial class autenticacionsmstaxista
    {

        [Key]
        public int idSms { get; set; }

        public int idTaxista { get; set; }

        [StringLength(15)]
        public string codigo { get; set; }

        public bool verificado { get; set; }

        public virtual taxistas taxistas { get; set; }

    }
}