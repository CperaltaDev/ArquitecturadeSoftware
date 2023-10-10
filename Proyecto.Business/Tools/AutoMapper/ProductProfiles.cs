using AutoMapper;
using Proyecto.Data.Dto;
using Proyecto.Data.Entities;


namespace Proyecto.Business.Tools.AutoMapper
{
    public class ProductProfiles : Profile

    {
        public ProductProfiles() 
        {
            CreateMap<Producto, Product>().ReverseMap();
        }
        
    }
}
