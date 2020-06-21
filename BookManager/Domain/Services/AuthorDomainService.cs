using BookManager.DataPersistence.Repository.Generic;
using BookManager.Domain.Entities;
using BookManager.Domain.Services.Contracts;
using System.Linq;

namespace BookManager.Domain.Services
{
    /// <summary>
    /// Implementa la logica de dominio
    /// </summary>
    public class AuthorDomainService : IAuthorDomainService
    {
        #region Fields
        /// <summary>
        /// Repositorio generico de Author
        /// </summary>
        private readonly IRepository<Author> _authorRepo;
        #endregion

        #region C'tor
        /// <summary>
        /// Inicia una nueva instancia de la clase
        /// </summary>
        /// <param name="authorRepo">repositorio de Author</param>
        public AuthorDomainService(IRepository<Author> authorRepo)
        {
            _authorRepo = authorRepo;
        }
        #endregion

        #region Method
        /// <summary>
        /// Crea un nuevo author
        /// </summary>
        /// <param name="author"> object author a crear</param>
        /// <returns>autor creado </returns>
        public dynamic Create(Author author)
        {
            if (author == null)
                return new { isSuccesfull = false, mesagess = $"El Objecto {nameof(author)}, no es valido" };

            if (string.IsNullOrWhiteSpace(author.Name))
            {
                return new { isSuccesfull = false, mesagess = $"El Nombre no puede ser vacio " };
            }

            Author result = _authorRepo.Create(author);
            int count = _authorRepo.SaveChanges();

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

            Author entity = _authorRepo.Entity.Find(id);

            if (entity is null)
            {
                return new { isSuccesfull = false, mesagess = $"No se encontro un registro con el identificador ({id})" };
            }

            Author result = _authorRepo.Remove(entity);
            int count = _authorRepo.SaveChanges();

            if (count == 0)
            {
                return new { isSuccesfull = false, mesagess = $"Ocurrio un error al intentar Eliminar el Registro intente Nuevamente" };
            }

            return new { isSuccesfull = true, Result = result };
        }
        /// <summary>
        /// Actualiza los datos de un author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public dynamic Update(Author author)
        {
            if (author is null)
            {
                return new { isSuccesfull = false, mesagess = $"El Objecto {nameof(author)}, no es valido" };
            }

            Author entity = _authorRepo.Entity.Find(author.Id);

            if (entity is null)
            {
                return new { isSuccesfull = false, mesagess = $"No se encontro un registro con el identificador ({author.Id})" };
            }

            entity.Name = author.Name;
            entity.LastName = author.LastName;
            entity.BirthDate = author.BirthDate;

            Author result = _authorRepo.Update(entity);
            int coun = _authorRepo.SaveChanges();

            if (coun == 0)
            {
                return new { isSuccesfull = false, mesagess = $"Ocurrio un error al intentar Actualizar el Registro intente Nuevamente" };
            }

            return new { isSuccesfull = true, Result = result };
        }
        /// <summary>
        /// Obtiene un autor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Get(int id)
        {
            if (id <= 0)
            {
                return new { isSuccesfull = false, mesagess = $"El identificador enviado no es valido" };
            }

            Author entity = _authorRepo.List(x => x.Id == id).FirstOrDefault();

            if (entity is null)
            {
                return new { isSuccesfull = false, mesagess = $"No se encontro un registro con el identificador ({id})" };
            }

            return new { isSuccesfull = true, Result = entity };
        }
        #endregion
    }
}
