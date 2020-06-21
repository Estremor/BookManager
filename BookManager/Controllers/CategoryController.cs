using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManager.Application.Contracts;
using BookManager.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    /// <summary>
    /// servicios de category
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Fields
        /// <summary>
        /// Servicio de aplicacion de category
        /// </summary>
        private readonly ICategoryAppService _categoryAppServ;
        #endregion
        #region C'tor
        /// <summary>
        /// Inicia una nueva instancia
        /// </summary>
        /// <param name="categoryAppServ"></param>
        public CategoryController(ICategoryAppService categoryAppServ)
        {
            _categoryAppServ = categoryAppServ;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Crea un Registro con una categoria
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(CategoryController.Create))]
        public ActionResult<dynamic> Create(CategoryDTO category) => _categoryAppServ.Create(category);
        /// <summary>
        /// Actualiza Una categoria
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(nameof(CategoryController.Update))]
        public ActionResult<dynamic> Update(CategoryDTO category) => _categoryAppServ.Update(category);
        /// <summary>
        /// Elimina un registro categoria por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(nameof(CategoryController.Delete))]
        public ActionResult<dynamic> Delete(int id) => _categoryAppServ.Delete(id);
        /// <summary>
        /// Obtiene Uno por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(CategoryController.Get))]
        public ActionResult<dynamic> Get(int id) => _categoryAppServ.Get(id);
        /// <summary>
        /// Lista todas las categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(CategoryController.List))]
        public ActionResult<dynamic> List() => _categoryAppServ.List();
        #endregion
    }
}
