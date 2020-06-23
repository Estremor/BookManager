using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.DTOs
{
    /// <summary>
    /// Objec book con detalle
    /// </summary>
    public class BookDetailDTO
    {
        /// <summary>
        /// Nombre del Libro
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// ISBN CODE
        /// </summary>
        public string ISBN { get; set; }
        /// <summary>
        /// autor del libro
        /// </summary>
        public string Autor { get; set; }
        /// <summary>
        /// Categoria del libro
        /// </summary>
        public string Categoria { get; set; }
    }
}
