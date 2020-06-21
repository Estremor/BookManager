using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.DataPersistence.Configuratios
{
    /// <summary>
    /// Clase de configuracion Category para el contexto BookManager
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Inicaia la configuracion de Category
        /// </summary>
        /// <param name="config"></param>
        public void Configure(EntityTypeBuilder<Category> config)
        {
            config.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            config.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);
        }
    }
}
