namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cabspotdb.clientes")]
    public partial class clientes
    {
        public static CabspotDB db = new CabspotDB();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            carreras = new HashSet<carreras>();
            sugerencias = new HashSet<sugerencias>();
            //autenticacionsms = new HashSet<autenticacionsms>();
        }

        [Key]
        public int idCliente { get; set; }

        public int? idPersona { get; set; }

        [StringLength(15)]
        public string nombreUsuario { get; set; }

        [StringLength(32)]
        public string apikey { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<carreras> carreras { get; set; }

        public virtual personas personas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sugerencias> sugerencias { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<autenticacionsms> autenticacionsms { get; set; }

        //generar codigo aleatorio para autenticar al cliente
        public static autenticacionsms generarCodigoCliente(int idCliente)
        {
            if (idCliente != null)
            {
                clientes cliente = db.clientes.Find(idCliente);
                if (cliente != null)
                {
                    Random random = new Random();
                    autenticacionsms sms = new autenticacionsms();

                    int otp = random.Next(100000, 999999);

                    //guardando sms
                    sms.idClienteMovil = idCliente;
                    sms.codigo = otp.ToString();

                    try
                    {
                        db.autenticacionSms.Add(sms);
                        db.SaveChanges();
                        return sms;

                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }

                return null;

            }
            return null;
        }
    }

    [NotMapped]
    public class clienteNuevo
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string telefonoMovil { get; set; }
        public string identificacion { get; set; }
        public string email { get; set; }
        public string genero { get; set; }
    }
}
