using BookManager.DataPersistence.Repository.Generic;
using BookManager.Domain.Entities;
using BookManager.Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Domain.Services
{
    /// <summary>
    /// Implementa Logica para Book
    /// </summary>
    public class BookDomainService : IBookDomainService
    {

        #region Fields
        /// <summary>
        /// repositorio generico de Book
        /// </summary>
        private readonly IRepository<Book> _bookRepo;
        /// <summary>
        /// Generic Repo author
        /// </summary>
        private readonly IRepository<Author> _authorRepo;
        /// <summary>
        /// Generic Repo Category
        /// </summary>
        private readonly IRepository<Category> _categoryRepo;
        #endregion

        #region C'tor
        /// <summary>
        /// Inicia una nueva Instancia de la clase
        /// </summary>
        /// <param name="bookRepo">book repo</param>
        /// <param name="authorRepo">author repo</param>
        /// <param name="categoryRepo"> category Repo</param>
        public BookDomainService(IRepository<Book> bookRepo, IRepository<Author> authorRepo, IRepository<Category> categoryRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _categoryRepo = categoryRepo;
        }
        #endregion

        #region Methods
        /// <summary>s
        /// Crea un nuevo Book
        /// </summary>
        /// <param name="book"> object Book a crear</param>
        /// <returns>autor creado </returns>
        public dynamic Create(Book book)
        {
            #region Book validation
            if (book == null)
                return new { isSuccesfull = false, mesagess = $"El Objecto {nameof(book)}, no es valido" };

            if (string.IsNullOrWhiteSpace(book.Name))
            {
                return new { isSuccesfull = false, mesagess = $"El {nameof(Book.Name)} no puede ser vacio " };
            }

            if (string.IsNullOrWhiteSpace(book.Isbn))
            {
                return new { isSuccesfull = false, mesagess = $"El {nameof(Book.Isbn)} no puede ser vacio " };
            }

            if (book.CategoryId <= 0)
            {
                return new { isSuccesfull = false, mesagess = $"El id de la categoria es obligatorio" };
            }

            if (book.AuthorId <= 0)
            {
                return new { isSuccesfull = false, mesagess = $"El id del author es obligatorio" };
            }
            #endregion

            #region Relation validation
            var author = _authorRepo.Entity.Find(book.AuthorId);

            if (author is null)
            {
                return new { isSuccesfull = false, mesagess = $"no existe un Author con el identificador {book.AuthorId}" };
            }

            if (_categoryRepo.Entity.Find(book.CategoryId) == null)
            {
                return new { isSuccesfull = false, mesagess = $"no existe una Categoria con el identificador {book.CategoryId}" };
            }
            #endregion

            bool replicate = _bookRepo.List(x => x.Isbn.Equals(book.Isbn)).Count > 0;
            if (replicate)
            {
                return new { isSuccesfull = false, mesagess = $"Ya existe un registro con {nameof(Book.Isbn)} ({book.Isbn})" };
            }

            Book result = _bookRepo.Create(book);
            int count = _bookRepo.SaveChanges();

            if (count == 0)
            {
                return new { isSuccesfull = false, mesagess = $"Ocurrio un error al intentar guardar el Registro Valide Datos e intente Nuevamente" };
            }

            return new { isSuccesfull = true, Result = result };
        }
        /// <summary>
        /// Elimina el registro que filtre por el identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Delete(int id)
        {
            if (id <= 0)
            {
                return new { isSuccesfull = false, mesagess = $"El identificador enviado no es valido" };
            }

            Book entity = _bookRepo.Entity.Find(id);

            if (entity is null)
            {
                return new { isSuccesfull = false, mesagess = $"No se encontro un registro con el identificador ({id})" };
            }

            Book result = _bookRepo.Remove(entity);
            int count = _bookRepo.SaveChanges();

            if (count == 0)
            {
                return new { isSuccesfull = false, mesagess = $"Ocurrio un error al intentar Eliminar el Registro intente Nuevamente" };
            }

            return new { isSuccesfull = true, Result = result };
        }
        /// <summary>
        /// Obtiene un book por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Get(int id)
        {
            if (id <= 0)
            {
                return new { isSuccesfull = false, mesagess = $"El identificador enviado no es valido" };
            }

            Book entity = _bookRepo.List(x => x.Id == id).FirstOrDefault();

            if (entity is null)
            {
                return new { isSuccesfull = false, mesagess = $"No se encontro un registro con el identificador ({id})" };
            }

            return new { isSuccesfull = true, Result = entity };
        }
        /// <summary>
        /// Actualiza un book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public dynamic Update(Book book)
        {
            #region Book validation
            if (book == null)
                return new { isSuccesfull = false, mesagess = $"El Objecto {nameof(book)}, no es valido" };

            if (string.IsNullOrWhiteSpace(book.Name))
            {
                return new { isSuccesfull = false, mesagess = $"El {nameof(Book.Name)} no puede ser vacio " };
            }

            if (string.IsNullOrWhiteSpace(book.Isbn))
            {
                return new { isSuccesfull = false, mesagess = $"El {nameof(Book.Isbn)} no puede ser vacio " };
            }

            if (book.CategoryId <= 0)
            {
                return new { isSuccesfull = false, mesagess = $"El id de la categoria es obligatorio" };
            }

            if (book.AuthorId <= 0)
            {
                return new { isSuccesfull = false, mesagess = $"El id del author es obligatorio" };
            }

            #endregion

            #region Relation validation
            var author = _authorRepo.Entity.Find(book.AuthorId);

            if (author is null)
            {
                return new { isSuccesfull = false, mesagess = $"no existe un Author con el identificador {book.AuthorId}" };
            }

            if (_categoryRepo.Entity.Find(book.CategoryId) == null)
            {
                return new { isSuccesfull = false, mesagess = $"no existe una Categoria con el identificador {book.CategoryId}" };
            }
            #endregion

            Book entity = _bookRepo.Entity.Find(book.Id);

            if (entity is null)
            {
                return new { isSuccesfull = false, mesagess = $"No se encontro un registro con el identificador ({book.Id})" };
            }

            entity.Name = book.Name;
            entity.CategoryId = book.CategoryId;
            entity.AuthorId = book.AuthorId;

            var result = _bookRepo.Update(entity);
            int coun = _bookRepo.SaveChanges();

            if (coun == 0)
            {
                return new { isSuccesfull = false, mesagess = $"Ocurrio un error al intentar Actualizar el Registro intente Nuevamente" };
            }

            return new { isSuccesfull = true, Result = result };
        }
        /// <summary>
        /// Lista Los libros Con sus categorias
        /// </summary>
        /// <returns></returns>
        public dynamic ListBooks()
        {
            return new
            {
                isSuccesfull = true,
                Result =
                _bookRepo
                .Entity
                .Include(x => x.Author)
                .Include(x => x.Category).ToList()
            };
        }

        /// <summary>
        /// Filtra libros segun las condiciones
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public dynamic FilterBook(string name, string category, string author)
        {
            var result = _bookRepo.Entity.Include(x => x.Author).Include(x => x.Category).ToList();

            if (!string.IsNullOrWhiteSpace(name))
                result =  result.Where(x => name.Trim().Contains(x.Name))?.ToList();
            if (!string.IsNullOrWhiteSpace(category) && category != "0")
                result = result.Where(x => x.CategoryId == Convert.ToInt32(category))?.ToList();
            if (!string.IsNullOrWhiteSpace(author) && author != "0")
                result =  result.Where(x => x.AuthorId == Convert.ToInt32(author.Trim()))?.ToList();

            return new { isSuccesfull = true, Result = result?.ToList() };
        }

        #endregion
    }
}
