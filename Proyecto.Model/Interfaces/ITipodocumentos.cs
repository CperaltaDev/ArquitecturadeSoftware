using Proyecto.Data.Dto;
using Proyecto.Data.Entities;
namespace Proyecto.Model.Interfaces
{
    public interface ITipodocumentos
    {
        Task<TipoDocumentos> SelectItem(int input);
        Task<List<TipoDocumentos>> SelectAll();
        Task AddItem(Documentos input);
        Task RemoveItem(TipoDocumentos input);
        Task UpdateItem(TipoDocumentos input);
    
      
    }
}
