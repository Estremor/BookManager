using BookManager.Domain.Entities;

namespace BookManager.Domain.Services.Contracts
{
    /// <summary>
    /// Contrato servicio de dominio para Author
    /// </summary>
    public interface IAuthorDomainService
    {
        #region Methods
        /// <summary>
        /// Crea un nuevo autor
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        dynamic Create(Author author);
        /// <summary>
        /// Actualiza un autor
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        dynamic Update(Author author);
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
        #endregion

    }
}
