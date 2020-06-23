using AutoMapper;
using BookManager.Application.Contracts;
using BookManager.DataPersistence.Repository.Generic;
using BookManager.Domain.Entities;
using BookManager.Domain.Services.Contracts;
using BookManager.DTOs;
using System;
using System.Collections.Generic;

namespace BookManager.Application
{
    /// <summary>
    /// Implementa el contrato de author
    /// </summary>
    public class AuthorAppService : IAuthorAppService
    {
        #region Fields
        /// <summary>
        /// Servicio de dominio de author
        /// </summary>
        private readonly IAuthorDomainService _authorServ;
        /// <summary>
        /// Repositorio Generico de Author
        /// </summary>
        private readonly IRepository<Author> _repository;
        /// <summary>
        /// Authommaper
        /// </summary>
        private readonly IMapper _mapper;
        #endregion

        #region C'tor
        /// <summary>
        /// Inicia una instancia de la clase
        /// </summary>
        /// <param name="authorServ"></param>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public AuthorAppService(IAuthorDomainService authorServ, IMapper mapper, IRepository<Author> repository)
        {
            _authorServ = authorServ;
            _mapper = mapper;
            _repository = repository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Crea un autor
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public dynamic Create(AuthorDTO author)
        {
            try
            {
                Author entity = _mapper.Map<Author>(author);
                return _authorServ.Create(entity);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Elimina un autor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Delete(int id)
        {
            try
            {
                return _authorServ.Delete(id);
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
                return _authorServ.Get(id);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Actualiza un autor
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public dynamic Update(AuthorDTO author)
        {
            try
            {
                Author entity = _mapper.Map<Author>(author);
                return _authorServ.Update(entity);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Lista Todos los autores
        /// </summary>
        /// <returns></returns>
        public dynamic List()
        {
            try
            {
                return new { isSuccesfull = true, Result = _mapper.Map<IEnumerable<AuthorDTO>>(_repository.List()) };
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        #endregion
    }
}
