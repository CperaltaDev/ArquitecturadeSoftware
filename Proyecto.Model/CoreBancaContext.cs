
using Microsoft.EntityFrameworkCore;
using Proyecto.Data.Entities;

namespace Proyecto.Model
{
    public class CoreBancaContext : DbContext
    {
        public CoreBancaContext(DbContextOptions<CoreBancaContext> options) : base(options) { }

   

        public virtual DbSet<Producto> Producto { get; set; }
        public DbSet<TipoDocumentos> TipoDocumento { get; set; }
        public DbSet<Documentos> Documentos { get; set; }



    }
}
