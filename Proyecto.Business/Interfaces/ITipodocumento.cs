using Proyecto.Data.Common;
using Proyecto.Data.Dto;
using Proyecto.Data.Entities;
using System.Threading.Tasks;

namespace Proyecto.Business.Interfaces
{
    public interface ITipodocumento
    {
        Task<TipoDocumentOut> Selectall();

        Task<BaseOut> UpdateItem(UpdateTipoDocumentIn update);

        Task<BaseOut> AddItem(DocumentoIn Add);



    }
}
