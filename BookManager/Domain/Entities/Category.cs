using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Domain.Entities
{
    /// <summary>
    /// Categoria
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Category()
        {
            Book = new HashSet<Book>();
        }
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Relacion
        /// </summary>
        public virtual ICollection<Book> Book { get; set; }
    }
}
