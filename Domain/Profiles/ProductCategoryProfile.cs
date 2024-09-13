using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace Domain.Profiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<ProductCategoryDTO, ProductCategory>();
        }
    }
}
