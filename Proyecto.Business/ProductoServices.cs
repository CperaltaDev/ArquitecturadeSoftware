using AutoMapper;
using Microsoft.Extensions.Configuration;
using Proyecto.Business.Interfaces;
using Proyecto.Data.Common;
using Proyecto.Data.Dto;
using Proyecto.Model.Interfaces;
using System.Diagnostics;
using System.Net;

namespace Proyecto.Business
{
    public class ProductoServices : IProducto
    {
        private readonly IProductos _productoDAL;
        private readonly Stopwatch _time;
        private readonly IMapper _mapper;
        public ProductoServices(IProductos context, IConfiguration configuration, IMapper mapper) 
        {
            _productoDAL = context;
            _time = new Stopwatch();
            IConfiguration _configuration = configuration;
            _mapper = mapper;

        }
        public async Task <ProductOut> Selectall()
        {
            var output = new ProductOut();
            output.ListProducto = new List<Product>();

            try
            {
                _time.Start();
                var reg = await _productoDAL.SelectAll();

                if (reg != null)
                {
                    reg.ForEach(item => output.ListProducto.Add(_mapper.Map<Product>(item)));
                    //foreach (var item in reg)
                    //{
                    //    Product product = new Product
                    //    {
                    //        Id = item.Id,
                    //        NombreProducto = item.NombreProducto,
                    //        CodigoProducto = item.CodigoProducto,
                    //        activo = item.activo

                    //    };

                    //    output.ListProducto.Add(product);
                    //}
               
                }
                                
            }
            catch (Exception ex)
            {
   
            }

            return output;
        }

        
    }


}
