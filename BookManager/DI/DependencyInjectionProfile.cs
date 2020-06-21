using BookManager.Application;
using BookManager.Application.Contracts;
using BookManager.DataPersistence.Repository.Generic;
using BookManager.Domain.Services;
using BookManager.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.DI
{
    /// <summary>
    /// Contiene la Configuracion de la injeccion de dependencias
    /// </summary>
    public class DependencyInjectionProfile
    {
        /// <summary>
        /// Registra Las dependencias, como se resuelven
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterProfile(IServiceCollection services)
        {
            #region Context
            /*Registramos el contexto*/
            services.AddTransient<Microsoft.EntityFrameworkCore.DbContext, DataPersistence.BookManagerDBContext>(s =>
            {
                DataPersistence.DbSettings settings = s.GetService<DataPersistence.DbSettings>();
                return new DataPersistence.BookManagerDBContext(settings);
            });
            #endregion

            #region Repositories
            /*Resolvemos los repositorios Genericos*/
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region Aplication
            services.AddTransient<IAuthorAppService, AuthorAppService>();
            services.AddTransient<IBookAppService, BookAppService>();
            services.AddTransient<ICategoryAppService, CategoryAppService>();
            #endregion

            #region Dominio
            services.AddTransient<IAuthorDomainService, AuthorDomainService>();
            services.AddTransient<IBookDomainService, BookDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            #endregion
        }
    }
}
