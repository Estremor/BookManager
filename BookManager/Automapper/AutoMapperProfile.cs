using AutoMapper;
using BookManager.Domain.Entities;
using BookManager.DTOs;

namespace BookManager.Automapper
{
    /// <summary>
    /// Configuracion de meppers
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Crea la configuracion
        /// </summary>
        public AutoMapperProfile()
        {
            #region Book
            CreateMap<Book, BookDTO>()
                .ForMember(dto => dto.Author, b => b.MapFrom(x => x.AuthorId))
                .ForMember(dto => dto.Nombre, b => b.MapFrom(x => x.Name))
                .ForMember(dto => dto.Category, b => b.MapFrom(x => x.CategoryId))
                .ForMember(dto => dto.Isbn, b => b.MapFrom(x => x.Isbn))
                .ForMember(dto => dto.Identificador, b => b.MapFrom(x => x.Id)); ;


            CreateMap<BookDTO, Book>().ForMember(x => x.AuthorId, dto => dto.MapFrom(x => x.Author))
                .ForMember(b => b.Name, dto => dto.MapFrom(x => x.Nombre))
                .ForMember(b => b.CategoryId, dto => dto.MapFrom(x => x.Category))
                .ForMember(b => b.Isbn, dto => dto.MapFrom(x => x.Isbn))
                .ForMember(b => b.Id, dto => dto.MapFrom(x => x.Identificador));
            #endregion

            #region Author
            CreateMap<Author, AuthorDTO>().ForMember(dto => dto.Identificador, a => a.MapFrom(x => x.Id))
                .ForMember(dto => dto.Nombre, a => a.MapFrom(x => x.Name))
                .ForMember(dto => dto.Apellido, a => a.MapFrom(x => x.LastName))
                .ForMember(dto => dto.FechaNacimiento, a => a.MapFrom(x => x.BirthDate));

            CreateMap<AuthorDTO, Author>()
                .ForMember(a => a.Id, dto => dto.MapFrom(x => x.Identificador))
                .ForMember(a => a.Name, dto => dto.MapFrom(x => x.Nombre))
                .ForMember(a => a.LastName, dto => dto.MapFrom(x => x.Apellido))
                .ForMember(a => a.BirthDate, dto => dto.MapFrom(x => x.FechaNacimiento));
            #endregion

            #region Category
            CreateMap<Category, CategoryDTO>()
                .ForMember(dto => dto.Identificador, c => c.MapFrom(x => x.Id))
                .ForMember(dto => dto.Nombre, c => c.MapFrom(x => x.Name))
                .ForMember(dto => dto.Descripcion, c => c.MapFrom(x => x.Description));

            CreateMap<CategoryDTO, Category>()
                .ForMember(c => c.Id, dto => dto.MapFrom(x => x.Identificador))
                .ForMember(c => c.Name, dto => dto.MapFrom(x => x.Nombre))
                .ForMember(c => c.Description, dto => dto.MapFrom(x => x.Descripcion));
            #endregion
        }
    }
}
