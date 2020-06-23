using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Domain.Entities
{
    /// <summary>
    /// autor
    /// </summary>
    public class Author
    {
        /// <summary>
        /// instamcia la clase
        /// </summary>
        public Author()
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
        /// Apellido
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Edad
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Relations
        /// </summary>
        public virtual ICollection<Book> Book { get; set; }
    }
}
