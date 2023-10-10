using Proyecto.Data.Dto;
using System.Threading.Tasks;

namespace Proyecto.Business.Interfaces
{
    public interface IProducto
    {
         Task <ProductOut> Selectall();
    }
}
