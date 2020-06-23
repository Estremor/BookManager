using BookManager.DataPersistence.Configuratios;
using Microsoft.EntityFrameworkCore;

namespace BookManager.DataPersistence
{
    /// <summary>
    /// Contexto de datos
    /// </summary>
    public class BookManagerDBContext : DbContext
    {
        #region Propesties
        /// <summary>
        /// Configuracion de conexion
        /// </summary>
        protected DbSettings DbSettings { get; private set; }
        #endregion

        #region C'tor
        /// <summary>
        /// Inicia el contexto de Datos
        /// </summary>
        /// <param name="dbSettings"></param>
        public BookManagerDBContext(DbSettings dbSettings) : base()
        {
            DbSettings = dbSettings;
            DbSettings.ConnectionString = DbSettings.ConnectionString;
            Database.EnsureCreated();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Se usa la configuracion 
        /// </summary>
        /// <param name="dbContextOptionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(DbSettings.ConnectionString);
        }
        /// <summary>
        /// Aplica la configuracion
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
        #endregion
    }

    /// <summary>
    /// encapsula las propiedades de configuracion de una conexion a sql
    /// </summary>
    public sealed class DbSettings
    {
        #region Properties
        /// <summary>
        /// Obtiene y asigna la cadena de conexion
        /// </summary>
        public string ConnectionString { get; set; }
        #endregion

    }
}
