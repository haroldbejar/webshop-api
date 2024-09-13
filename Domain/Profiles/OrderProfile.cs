using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace Domain.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
