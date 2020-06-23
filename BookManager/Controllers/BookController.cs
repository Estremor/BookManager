using BookManager.Application.Contracts;
using BookManager.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    /// <summary>
    /// Servicio de book
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region Fields
        /// <summary>
        /// Servicio de aplicacion de Book
        /// </summary>
        private readonly IBookAppService _bookAppServ;
        #endregion
        #region C'tor
        /// <summary>
        /// Inicia una nueva instancia
        /// </summary>
        /// <param name="bookAppServ"></param>
        public BookController(IBookAppService bookAppServ)
        {
            _bookAppServ = bookAppServ;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Crea un Registro con un book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(BookController.Create))]
        public ActionResult<dynamic> Create(BookDTO book) => _bookAppServ.Create(book);
        /// <summary>
        /// Actualiza Un book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(nameof(BookController.Update))]
        public ActionResult<dynamic> Update(BookDTO book) => _bookAppServ.Update(book);
        /// <summary>
        /// Elimina un registro book por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(nameof(BookController.Delete))]
        public ActionResult<dynamic> Delete(int id) => _bookAppServ.Delete(id);
        /// <summary>
        /// Obtiene Uno por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(BookController.Get))]
        public ActionResult<dynamic> Get(int id) => _bookAppServ.Get(id);
        /// <summary>
        /// Lista todos los books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(BookController.List))]
        public ActionResult<dynamic> List() => _bookAppServ.ListBooks();

        /// <summary>
        /// Busca por los filtros enviados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(BookController.FindFilter))]
        public ActionResult<dynamic> FindFilter(string name, string categori, string autor)
        {
            return _bookAppServ.Filter(name, categori, autor);
        }
        #endregion
    }
}
