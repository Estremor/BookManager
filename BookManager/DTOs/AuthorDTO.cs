using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.DTOs
{
    /// <summary>
    /// Encapsula los datos de un author
    /// </summary>
    public class AuthorDTO
    {
        /// <summary>
        /// Identificador unico del author
        /// </summary>
        public int Identificador { get; set; }
        /// <summary>
        /// Nombre del autor
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Apellido del author (opcional) => si se desconoce
        /// </summary>
        public string Apellido { get; set; }
        /// <summary>
        /// fecha de Nacimiento (opcional) => si se desconoce
        /// </summary>
        public DateTime? FechaNacimiento { get; set; }
    }
}
