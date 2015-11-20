using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cabspot.Models;

namespace Cabspot.Controllers
{
    public class requestSms
    {
        CabspotDB db = new CabspotDB();

        public int generarCodigo()
        {
            Array response;
            contactos contacto = new contactos();
            personas persona = new personas();
            clientes cliente = new clientes();
            autenticacionSms sms = new autenticacionSms();

            Random random = new Random();

            if (contacto.telefonoMovil != null)
            {
                String nombres = persona.nombres;
                String correo = contacto.email;
                String celular = contacto.telefonoMovil;

                int otp = random.Next(100000, 999999);



            }
            return 0;
        }        
    }
}