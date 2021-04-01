using AutoMapper;
using BLL.ModelsDto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MaperConfigs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Autor, AutorDto>();
            CreateMap<AutorDto, Autor>();
            
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

        }
    }
}