using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.DTOs
{
    /// <summary>
    /// Encapsula los Datos de una categoria
    /// </summary>
    public class CategoryDTO
    {
        /// <summary>
        /// identificador unico
        /// </summary>
        public int Identificador { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
    }
}
