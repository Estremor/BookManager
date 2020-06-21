using AutoMapper;
using BookManager.Application.Contracts;
using BookManager.DataPersistence.Repository.Generic;
using BookManager.Domain.Entities;
using BookManager.Domain.Services.Contracts;
using BookManager.DTOs;
using System;

namespace BookManager.Application
{
    /// <summary>
    /// Implementacion de servicio de aplicacion category
    /// </summary>
    public class CategoryAppService : ICategoryAppService
    {
        #region Fields
        /// <summary>
        /// Servicio de dominio de category
        /// </summary>
        private readonly ICategoryDomainService _categoryServe;
        /// <summary>
        /// Repositori Generico de category
        /// </summary>
        private readonly IRepository<Category> _repository;
        /// <summary>
        /// Autompper
        /// </summary>
        private readonly IMapper _mapper;
        #endregion

        #region C'tor
        /// <summary>
        /// Inicia una nueva instancia de la clase
        /// </summary>
        /// <param name="categoryServe"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public CategoryAppService(ICategoryDomainService categoryServe, IRepository<Category> repository, IMapper mapper)
        {
            _categoryServe = categoryServe;
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Crea una categoria
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public dynamic Create(CategoryDTO category)
        {
            try
            {
                Category entity = _mapper.Map<Category>(category);
                return _categoryServe.Create(entity);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Elimina una categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Delete(int id)
        {
            try
            {
                return _categoryServe.Delete(id);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Obtiene uno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Get(int id)
        {
            try
            {
                return _categoryServe.Get(id);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Lista
        /// </summary>
        /// <returns></returns>
        public dynamic List()
        {
            try
            {
                return new { isSuccesfull = true, Result = _repository.List() };
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Actualiza
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public dynamic Update(CategoryDTO category)
        {
            try
            {
                Category entity = _mapper.Map<Category>(category);
                return _categoryServe.Update(entity);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        #endregion
    }
}
