using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManager.Application.Contracts;
using BookManager.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    /// <summary>
    /// Servicios de author
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        #region Fields
        /// <summary>
        /// Servicio de aplicacion de Author
        /// </summary>
        private readonly IAuthorAppService _authorAppServ;
        #endregion
        #region C'tor
        /// <summary>
        /// Inicia una nueva instancia
        /// </summary>
        /// <param name="authorAppServ"></param>
        public AuthorController(IAuthorAppService authorAppServ)
        {
            _authorAppServ = authorAppServ;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Crea un Registro con un author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(AuthorController.Create))]
        public ActionResult<dynamic> Create(AuthorDTO author) => _authorAppServ.Create(author);
        /// <summary>
        /// Actualiza Un author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(nameof(AuthorController.Update))]
        public ActionResult<dynamic> Update(AuthorDTO author) => _authorAppServ.Update(author);
        /// <summary>
        /// Elimina un registro author por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(nameof(AuthorController.Delete))]
        public ActionResult<dynamic> Delete(int id) => _authorAppServ.Delete(id);
        /// <summary>
        /// Obtiene Uno por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(AuthorController.Get))]
        public ActionResult<dynamic> Get(int id) => _authorAppServ.Get(id);
        /// <summary>
        /// Lista Todos los autores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(AuthorController.List))]
        public ActionResult<dynamic> List() => _authorAppServ.List();
        #endregion
    }
}
