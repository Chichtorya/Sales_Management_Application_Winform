using AutoMapper;
using BusinessObject;

namespace DataAccess
{
    public class MappingProfile : Profile
    {
 
        public MappingProfile()
        {
            CreateMap<Member, Member>().ReverseMap();
            CreateMap<Product, Product>().ReverseMap();
            CreateMap<Order, Order>().ReverseMap();
            CreateMap<OrderDetail, OrderDetail>().ReverseMap();
        }


        
        
}
}






