using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace Domain.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
