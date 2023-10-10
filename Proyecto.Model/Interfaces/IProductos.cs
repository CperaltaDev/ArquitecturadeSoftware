using Proyecto.Data.Entities;


namespace Proyecto.Model.Interfaces
{
    public interface IProductos
    {
        Task<Producto> SelectItem(int input);
        Task<List<Producto>> SelectAll();
        Task AddItem(Producto input);
        Task RemoveItem(Producto input);
        Task UpdateItem(Producto input);
    }
}
