using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Dto;


namespace WebApplication1.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile() { 

        Mapper.CreateMap<Customer, CustomerDto>().ForMember(c => c.CustomerId, opt => opt.Ignore()); ;
        Mapper.CreateMap<CustomerDto, Customer >();

            Mapper.CreateMap<Product, ProductDto>().ForMember(c => c.ProductID, opt => opt.Ignore()); ;
            Mapper.CreateMap<ProductDto, Product>();

        }

    }
}