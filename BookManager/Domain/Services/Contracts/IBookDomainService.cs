using BookManager.Domain.Entities;

namespace BookManager.Domain.Services.Contracts
{
    /// <summary>
    /// Contrato para servicio de dominio de libros
    /// </summary>
    public interface IBookDomainService
    {
        /// <summary>
        /// Crea un nuevo Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        dynamic Create(Book book);
        /// <summary>
        /// Actualiza un autor
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        dynamic Update(Book book);
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
