using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.DTOs
{
    /// <summary>
    /// encapsula los datos de un libro
    /// </summary>
    public class BookDTO
    {
        /// <summary>
        /// identificador Unico
        /// </summary>
        public int Identificador { get; set; }
        /// <summary>
        /// Nombre para el libro
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Autor del Libro
        /// </summary>
        public int Author { get; set; }
        /// <summary>
        /// Categoria a la que pertenece
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        /// Codigo Unico del libro (13 caracteres maximo)
        /// (no se actualiza por seguridad)
        /// </summary>
        public string Isbn { get; set; }
    }
}
