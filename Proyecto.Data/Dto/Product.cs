using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Data.Dto
{
    public class Product
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public bool activo { get; set; }
    }
}
