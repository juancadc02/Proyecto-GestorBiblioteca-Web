using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servicios
{
    /// <summary>
    /// Interfaz que define el metodo de encriptar contraseña
    /// </summary>
    public interface servicioEncriptarContraseña
    {
        /// <summary>
        /// Interfaz del metodo encargado de encriptar la contrasela
        /// </summary>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        public  string EncriptarContraseña(string contraseña);
    }
}
