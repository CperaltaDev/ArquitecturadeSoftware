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
    public class TipoDocumentoDB : ITipodocumentos
    {
        private readonly CoreBancaContext _context;
        public TipoDocumentoDB(CoreBancaContext context)
        {
            _context = context;
        }
        public async Task AddItem(Documentos input)
        {
            _context.Documentos.Add(input);
            await _context.SaveChangesAsync();
        }

        public Task RemoveItem(TipoDocumentos input)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipoDocumentos>> SelectAll()
        {
            return await _context.TipoDocumento.ToListAsync();
        }

        public async Task <TipoDocumentos> SelectItem(int id)
        {
            return await _context.TipoDocumento.Where(r => r.Id == id).FirstOrDefaultAsync();
        }


        public async Task UpdateItem(TipoDocumentos input)
        {
            _context.TipoDocumento.Update(input);
            await _context.SaveChangesAsync();
        }

    }
}
