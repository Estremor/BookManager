using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.DataPersistence.Configuratios
{
    /// <summary>
    /// Clase de configuracion Book para el contexto BookManager
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        /// <summary>
        /// Inicaia la configuracion de Book
        /// </summary>
        /// <param name="config"></param>
        public void Configure(EntityTypeBuilder<Book> config)
        {
            config.Property(e => e.Isbn)
                .IsRequired()
                .HasColumnName("ISBN")
                .HasMaxLength(13)
                .IsUnicode(false);

            config.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            config.HasOne(d => d.Author)
                .WithMany(p => p.Book)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Author");

            config.HasOne(d => d.Category)
                .WithMany(p => p.Book)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Category");
        }
    }
}
