using BookManager.DataPersistence.Repository.Generic;
using BookManager.Domain.Entities;
using BookManager.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Domain.Services
{
    /// <summary>
    /// implementacion de lgica servicio de Category
    /// </summary>
    public class CategoryDomainService : ICategoryDomainService
    {
        #region Fields
        /// <summary>
        /// Repositorio Generico de categoria
        /// </summary>
        private readonly IRepository<Category> _categoryRepo;
        #endregion

        #region C'tor
        /// <summary>
        /// Inicia una nueva instancia de la clase
        /// </summary>
        /// <param name="categoryRepo"></param>
        public CategoryDomainService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        #endregion

        #region Method
        /// <summary>
        /// Crea un nuevo Category
        /// </summary>
        /// <param name="category"> object category a crear</param>
        /// <returns>autor creado </returns>
        public dynamic Create(Category category)
        {
            if (category == null)
                return new { isSuccesfull = false, mesagess = $"El Objecto {nameof(category)}, no es valido" };

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                return new { isSuccesfull = false, mesagess = $"El Nombre no puede ser vacio " };
            }

            if (string.IsNullOrWhiteSpace(category.Description))
            {
                return new { isSuccesfull = false, mesagess = $"las Descripcion no puede ser vacia " };
            }

            Category result = _categoryRepo.Create(category);
            int count = _categoryRepo.SaveChanges();

            if (count == 0)
            {
                return new { isSuccesfull = false, mesagess = $"Ocurrio un error al intentar guardar el Registro Valide Datos e intente Nuevamente" };
            }

            return new { isSuccesfull = true, Result = result };
        }
        /// <summary>
        /// Elimina el registro que filtre por el identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Delete(int id)
        {
            if (id <= 0)
            {
                return new { isSuccesfull = false, mesagess = $"El identificador enviado no es valido" };
            }

            Category entity = _categoryRepo.Entity.Find(id);

            if (entity is null)
            {
                return new { isSuccesfull = false, mesagess = $"No se encontro un registro con el identificador ({id})" };
            }

            Category result = _categoryRepo.Remove(entity);
            int count = _categoryRepo.SaveChanges();

            if (count == 0)
            {
                return new { isSuccesfull = false, mesagess = $"Ocurrio un error al intentar Eliminar el Registro intente Nuevamente" };
            }

            return new { isSuccesfull = true, Result = result };
        }
        /// <summary>
        /// Obtiene una categoria por id
        /// </summary>
        /// <param name="id">isentificador </param>
        /// <returns></returns>
        public dynamic Get(int id)
        {
            if (id <= 0)
            {
                return new { isSuccesfull = false, mesagess = $"El identificador enviado no es valido" };
            }

            Category entity = _categoryRepo.List(x => x.Id == id).FirstOrDefault();

            if (entity is null)
            {
                return new { isSuccesfull = false, mesagess = $"No se encontro un registro con el identificador ({id})" };
            }

            return new { isSuccesfull = true, Result = entity };
        }
        /// <summary>
        /// Actualiza los datos de un category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public dynamic Update(Category category)
        {

            if (category is null)
            {
                return new { isSuccesfull = false, mesagess = $"El Objecto {nameof(category)}, no es valido" };
            }

            Category entity = _categoryRepo.Entity.Find(category.Id);

            if (entity is null)
            {
                return new { isSuccesfull = false, mesagess = $"No se encontro un registro con el identificador ({category.Id})" };
            }

            entity.Name = category.Name;
            entity.Description = category.Description;

            Category result = _categoryRepo.Update(entity);
            int coun = _categoryRepo.SaveChanges();

            if (coun == 0)
            {
                return new { isSuccesfull = false, mesagess = $"Ocurrio un error al intentar Actualizar el Registro intente Nuevamente" };
            }

            return new { isSuccesfull = true, Result = result };
        }
        #endregion
    }
}
