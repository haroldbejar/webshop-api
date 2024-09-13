using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace Domain.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
