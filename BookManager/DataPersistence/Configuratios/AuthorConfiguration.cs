using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.DataPersistence.Configuratios
{
    /// <summary>
    /// Clase de configuracion Author para el contexto BookManager
    /// </summary>
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        /// <summary>
        /// Inicaia la configuracion de Author
        /// </summary>
        /// <param name="config"></param>
        public void Configure(EntityTypeBuilder<Author> config)
        {

            config.Property(e => e.BirthDate)
                .HasColumnType("date");

            config.Property(e => e.LastName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

            config.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
        }
    }
}
