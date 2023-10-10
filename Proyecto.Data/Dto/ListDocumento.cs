using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Data.Dto
{
    public class ListDocumento
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
  
        public string Identificacion { get; set; }
 
        public string Extension { get; set; }

        public string CodigoProducto { get; set; }
 
        public string CodigoDocumento { get; set; }
      
        public string Activo { get; set; }
    }
}
