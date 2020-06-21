using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Isbn { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }
}
