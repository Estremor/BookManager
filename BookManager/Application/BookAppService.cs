using AutoMapper;
using BookManager.Application.Contracts;
using BookManager.Domain.Entities;
using BookManager.Domain.Services.Contracts;
using BookManager.DTOs;
using System;

namespace BookManager.Application
{
    /// <summary>
    /// Implementacion de servicio de aplicacion de book
    /// </summary>
    public class BookAppService : IBookAppService
    {
        #region Fields
        /// <summary>
        /// Servicio de dominio de book
        /// </summary>
        private readonly IBookDomainService _bookDomainServ;
        /// <summary>
        /// Autommaper
        /// </summary>
        private readonly IMapper _mapper;
        #endregion

        #region C'tor
        /// <summary>
        /// Inicia una nueva instancia de la clase
        /// </summary>
        /// <param name="bookDomainServ"></param>
        /// <param name="mapper"></param>
        public BookAppService(IBookDomainService bookDomainServ, IMapper mapper)
        {
            _bookDomainServ = bookDomainServ;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Crea uno nuevo
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public dynamic Create(BookDTO book)
        {
            try
            {
                Book entity = _mapper.Map<Book>(book);
                return _bookDomainServ.Create(entity);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Elimina un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Delete(int id)
        {
            try
            {
                return _bookDomainServ.Delete(id);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Busca uno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Get(int id)
        {
            try
            {
                return _bookDomainServ.Get(id);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Lista todo con dependencias
        /// </summary>
        /// <returns></returns>
        public dynamic ListBooks()
        {
            try
            {
                return _bookDomainServ.ListBooks();
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        /// <summary>
        /// Actualiza
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public dynamic Update(BookDTO book)
        {
            try
            {
                Book entity = _mapper.Map<Book>(book);
                return _bookDomainServ.Update(entity);
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        #endregion
    }
}
