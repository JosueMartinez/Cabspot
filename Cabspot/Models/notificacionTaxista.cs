using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cabspot.Models
{
    [Table("notificacionTaxista")]
    public partial class notificacionTaxista
    {
        [Key]
        public int idNotificacion { get; set; }

        public int idTaxista { get; set; }

        public string tramaJson { get; set; }

        public virtual taxistas taxista { get; set; }
    }
}