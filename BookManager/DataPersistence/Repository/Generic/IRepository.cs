using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookManager.DataPersistence.Repository.Generic
{
    #region Repo
    /// <summary>
    /// Comportamiento de un repository
    /// </summary>
    public interface IRepository
    {
        #region Properties
        /// <summary>
        /// Contexto de Datos
        /// </summary>
        DbContext Context { get; }
        #endregion
    }
    #endregion

    #region Generic Repo
    /// <summary>
    /// define el comportamiento del repo
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : class, new()
    {
        #region Properties
        /// <summary>
        /// Obtiene la entidad para dar acceso a el contexto
        /// </summary>
        DbSet<TEntity> Entity { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Inserta una nueva entidad en el repositorio de Datos
        /// </summary>
        /// <param name="entity">entidad que se va a crear</param>
        /// <returns>Entidad insertada</returns>
        TEntity Create(TEntity entity);
        /// <summary>
        /// Actualiza una entidad 
        /// </summary>
        /// <param name="entity">Entidad a Actualizar</param>
        /// <returns>entidad actualizada</returns>
        TEntity Update(TEntity entity);
        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        /// <returns>Entidad que se elimino</returns>
        TEntity Remove(TEntity entity);
        /// <summary>
        /// Lista todas las entidades o las que cumplan con la expresion
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        ICollection<TEntity> List(Expression<Func<TEntity, bool>> expression = null);
        /// <summary>
        /// Confirma los cambios
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        #endregion
    }
    #endregion
}
