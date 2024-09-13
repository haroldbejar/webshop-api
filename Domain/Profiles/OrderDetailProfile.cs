using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace Domain.Profiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<OrderDetailDTO, OrderDetail>();
        }
    }
}
