using BookManager.DTOs;

namespace BookManager.Application.Contracts
{
    /// <summary>
    /// Servicio de aplicacion de Author
    /// </summary>
    public interface IAuthorAppService
    {
        #region Methods
        /// <summary>
        /// Crea un nuevo autor
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        dynamic Create(AuthorDTO author);
        /// <summary>
        /// Actualiza un autor
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        dynamic Update(AuthorDTO author);
        /// <summary>
        /// Elimina un autor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        dynamic Delete(int id);
        /// <summary>
        /// Obtiene un autor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        dynamic Get(int id);
        /// <summary>
        /// Lista Todos los autores
        /// </summary>
        /// <returns></returns>
        dynamic List();
        #endregion
    }
}
