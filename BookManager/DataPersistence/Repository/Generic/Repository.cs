using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookManager.DataPersistence.Repository.Generic
{
    /// <summary>
    /// Implementa el contrato
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        #region Properties

        /// <summary>
        /// Entidad que da acceso a el contexto
        /// </summary>
        public DbSet<TEntity> Entity { get; private set; }
        /// <summary>
        /// Obtiene el contexto de datos
        /// </summary>
        public DbContext Context { get; private set; }
        #endregion

        #region C'tor
        /// <summary>
        /// Inicia el repo
        /// </summary>
        public Repository(DbContext dbContext)
        {
            Context = dbContext;
            Entity = Context.Set<TEntity>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inserta La entidad (context)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Create(TEntity entity)
        {
            var resultentity = Entity.Add(entity);
            return resultentity.Entity;
        }
        /// <summary>
        /// Actualiza la entidad (context)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            var resultEntity = Entity.Update(entity);
            return resultEntity.Entity;
        }
        /// <summary>
        /// var Elimina la entidad (context)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Remove(TEntity entity)
        {
            var resultEntity = Entity.Remove(entity);
            return resultEntity.Entity;
        }
        /// <summary>
        /// Lista todas las entidades o las que cumplan con la expresion
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public ICollection<TEntity> List(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression is null) return Entity.ToList();

            return Entity.Where(expression).ToList();
        }
        /// <summary>
        /// Confirma los Cambios
        /// </summary>
        /// <returns></returns>
        public int SaveChanges() => Context.SaveChanges();
        #endregion
    }
}
