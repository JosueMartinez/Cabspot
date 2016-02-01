using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cabspot.Models
{
    [Table("notificacionCliente")]
    public partial class notificacionCliente
    {
        [Key]
        public int idNotificacion { get; set; }                
        
        public int idCliente { get; set; }
                
        public string tramaJson { get; set; }

        public virtual clientes clientes { get; set; }
    }
}