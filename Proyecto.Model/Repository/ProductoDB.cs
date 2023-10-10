using Microsoft.EntityFrameworkCore;
using Proyecto.Data.Entities;
using Proyecto.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model.Repository
{
    public class ProductoDB : IProductos
    {
        private readonly CoreBancaContext _context;
        public ProductoDB(CoreBancaContext context) 
        {
            _context = context;
        }
        public Task AddItem(Producto input)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItem(Producto input)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> SelectAll()
        {
            return await _context.Producto.ToListAsync();
        }

        public Task<Producto> SelectItem(int input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItem(Producto input)
        {
            throw new NotImplementedException();
        }
    }
}
