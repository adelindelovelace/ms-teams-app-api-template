using AutoMapper;
using MS_Teams_API.Application.Features.Products.Commands.CreateProduct;
using MS_Teams_API.Application.Features.Products.Queries.GetAllProducts;
using MS_Teams_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Teams_API.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
