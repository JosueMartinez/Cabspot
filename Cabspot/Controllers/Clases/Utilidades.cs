using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cabspot.Controllers.Clases
{
    public class Utilidades
    {
        public static string RutaRelativa(string filePath, string referencePath)
        {
            var fileUri = new Uri(filePath);
            var referenceUri = new Uri(referencePath);
            return referenceUri.MakeRelativeUri(fileUri).ToString();
        }
    }
}