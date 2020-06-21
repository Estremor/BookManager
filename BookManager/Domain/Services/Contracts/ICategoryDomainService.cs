using BookManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Domain.Services.Contracts
{
    /// <summary>
    /// Contrato servicio de dominio para Category
    /// </summary>
    public interface ICategoryDomainService
    {
        /// <summary>
        /// Crea un nuevo category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        dynamic Create(Category category);
        /// <summary>
        /// Actualiza un autor
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        dynamic Update(Category category);
        /// <summary>
        /// Elimina un category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        dynamic Delete(int id);
        /// <summary>
        /// Obtiene un category por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        dynamic Get(int id);
    }
}
