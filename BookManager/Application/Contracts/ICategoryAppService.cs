using BookManager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Application.Contracts
{
    /// <summary>
    /// Contrato servicio de aplicacion de Category
    /// </summary>
    public interface ICategoryAppService
    {
        /// <summary>
        /// Crea un nuevo category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        dynamic Create(CategoryDTO category);
        /// <summary>
        /// Actualiza un autor
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        dynamic Update(CategoryDTO category);
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
        /// <summary>
        /// Lista Todas las Categorias
        /// </summary>
        /// <returns></returns>
        dynamic List();
    }
}
