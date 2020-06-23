using AutoMapper;
using BookManager.Application.Contracts;
using BookManager.Domain.Entities;
using BookManager.Domain.Services.Contracts;
using BookManager.DTOs;
using System;
using System.Collections.Generic;

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
                var result = _bookDomainServ.ListBooks();
                if (result.isSuccesfull)
                {
                    return new { isSuccesfull = true, Result = _mapper.Map<IEnumerable<BookDTO>>(result.Result) };
                }

                return new { isSuccesfull = false, Messges = result.Messges };
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
                var result = _bookDomainServ.Update(entity);
                if (!result.isSuccesfull)
                {
                    return new { isSuccesfull = false, result.Messges };
                }
                return new { isSuccesfull = true, Result = _mapper.Map<BookDTO>(result) };
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }

        /// <summary>
        /// Filtra libros por author nombre de libro autor
        /// </summary>
        /// <param name="name">Nombre del libro</param>
        /// <param name="category"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public dynamic Filter(string name, string category, string author)
        {
            try
            {
                var result = _bookDomainServ.FilterBook(name, category, author);
                return new { isSuccesfull = true, Result = _mapper.Map<IEnumerable<BookDetailDTO>>(result.Result) };
            }
            catch (Exception e)
            {
                return new { isSuccesfull = false, Messges = e.Message };
            }
        }
        #endregion
    }
}
