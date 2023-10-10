using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Data.Dto
{
    public class TipoDocument
    {
        public int Id { get; set; }
        public string NombreDocumento { get; set; }
        public string CodigoDocumento { get; set; }
        public string CodigoProducto { get; set; }
        public bool activo { get; set; }
    }
}
