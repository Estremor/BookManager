using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Domain.Entities
{
    /// <summary>
    /// Libro
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Author
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Categoria
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Code libro
        /// </summary>
        public string Isbn { get; set; }
        /// <summary>
        /// relacion
        /// </summary>
        public virtual Author Author { get; set; }
        /// <summary>
        /// Relacion
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
