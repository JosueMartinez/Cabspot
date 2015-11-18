using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Cabspot.Models
{
    [Table("cabspotdb.autenticacionSms")]
    public partial class autenticacionSms
    {

        [Key]
        public int idSms { get; set; }

        [ForeignKey("clientes")]
        public int idCliente { get; set; }

        [StringLength(15)]
        public string codigo { get; set; }

        public bool verificado { get; set; }

        public virtual clientes clientes { get; set; }

    }
}