using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servicios
{
    internal interface servicioEncriptarContraseña
    {
        public  string EncriptarContraseña(string contraseña);
    }
}
