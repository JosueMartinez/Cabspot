namespace Cabspot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    using System.Linq;

    [Table("taxistas")]
    [Serializable]
    public partial class taxistas
    {
        public static CabspotDB db = new CabspotDB();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taxistas()
        {
            carreras = new HashSet<carreras>();
            solicitudes = new HashSet<solicitudes>();
            vehiculos = new HashSet<vehiculos>();
        }

        [Key]
        public int idTaxista { get; set; }

        public int idPersona { get; set; }

        [Required(ErrorMessage="Debe especificar un código")]
        [StringLength(10)]
        [Column("codigoTaxista")]
        [Display(Name = "Código Taxista")]
        public string codigoTaxista { get; set; }

        [Display(Name = "Rating")]
        public int? rating { get; set; }

        public int? idEstadoDisponibilidad { get; set; }

        public int? idBase { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        public int? registradoPor { get; set; }

        public double? latitudActual { get; set; }

        public double? longitudActual { get; set; }

        public DateTime? ultimaActualizacionPosicion { get; set; }

        public virtual personas personas { get; set; }

        public virtual estadodisponibilidad estadodisponibilidad { get; set; }

        [NotMapped]
        public virtual vehiculos vehiculo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<carreras> carreras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<solicitudes> solicitudes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehiculos> vehiculos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<autenticacionsmstaxista> autenticacionsmstaxista { get; set; }

        //not mapped-----------------------------------------------------
        [NotMapped]
        public SelectList listaBases { get; set; }
        [NotMapped]
        [Display(Name = "Base")]
        public string baseSeleccionada { get; set; }


        //buscar al taxista por telefonoMovil
        public static taxistas BuscarPorMovil(string telefonoMovil)
        {
            if (!string.IsNullOrEmpty(telefonoMovil))
            {
                var taxistas = from t in db.taxistas where t.personas.contactos.telefonoMovil.Equals(telefonoMovil) select t;
                if (taxistas.Count() > 0)
                {
                    return taxistas.First();
                }
                return null;
            }
            return null;
        }

        //buscar taxista por codigo
        public static taxistas BuscarPorCodigo(string codigoTaxista)
        {
            if (!string.IsNullOrEmpty(codigoTaxista))
            {
                var taxistas = from t in db.taxistas where t.codigoTaxista.Equals(codigoTaxista) select t;
                if (taxistas.Count() > 0)
                {
                    return taxistas.First();
                }
                return null;
            }
            return null;
        }

        //generar codigo aleatorio para autenticar al taxista
        public static autenticacionsmstaxista generarCodigoTaxista(int idTaxista)
        {
            if (idTaxista != null)
            {
                taxistas taxista = db.taxistas.Find(idTaxista);
                if (taxista != null)
                {
                    Random random = new Random();
                    autenticacionsmstaxista sms = new autenticacionsmstaxista();

                    int otp = random.Next(100000, 999999);

                    //guardando sms
                    sms.idTaxista = idTaxista;
                    sms.codigo = otp.ToString();

                    try
                    {
                        db.autenticacionSmsTaxista.Add(sms);
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
}
