using BookManager.DTOs;

namespace BookManager.Application.Contracts
{
    /// <summary>
    /// Servicio de aplicacion de libro
    /// </summary>
    public interface IBookAppService
    {
        /// <summary>
        /// Crea un nuevo Book
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        dynamic Create(BookDTO book);
        /// <summary>
        /// Actualiza un autor
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        dynamic Update(BookDTO book);
        /// <summary>
        /// Elimina un Book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        dynamic Delete(int id);
        /// <summary>
        /// Obtiene un Book por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        dynamic Get(int id);
        /// <summary>
        /// Lista Libros
        /// </summary>
        /// <returns></returns>
        dynamic ListBooks();
    }
}
