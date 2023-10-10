using AutoMapper;
using Microsoft.Extensions.Configuration;
using Proyecto.Business.Interfaces;
using Proyecto.Data.Common;
using Proyecto.Data.Dto;
using Proyecto.Data.Entities;
using Proyecto.Model.Interfaces;
using System.Diagnostics;
using System.Net;


namespace Proyecto.Business
{
    public class TDocumentoServices : ITipodocumento
    {
        private readonly ITipodocumentos _TipoDocumentoDAL;
        private readonly Stopwatch _time;
        private readonly IMapper _mapper;
        public TDocumentoServices(ITipodocumentos context, IConfiguration configuration, IMapper mapper)
        {
            _TipoDocumentoDAL = context;
            _time = new Stopwatch();
            IConfiguration _configuration = configuration;
           _mapper = mapper;

        }

        public async Task<BaseOut> AddItem(DocumentoIn input)
        {
            var output = new BaseOut();

            try
            {
                _time.Start();
                var reg = _mapper.Map<Documentos>(input);
                await _TipoDocumentoDAL.AddItem(reg);
                output.result = Result.Success;
                output.message = "Operación Exitosa";
                output.StatusCode = HttpStatusCode.OK;
                _time.Stop();

            }
            catch (Exception ex)
            {
                output.result = Result.Error;
                output.message = "Error";
                output.StatusCode = HttpStatusCode.InternalServerError;
            }

            return output;
        }

        public Task RemoveItem(TipoDocumentos input)
        {
            throw new NotImplementedException();
        }

        public async Task<TipoDocumentOut> Selectall()
        {
            var output = new TipoDocumentOut { ListTipoDocumento = new() };

            try
            {
                _time.Start();
                var reg = await _TipoDocumentoDAL.SelectAll();

                if (reg != null)
                {
                    reg.ForEach(item => output.ListTipoDocumento.Add(_mapper.Map<TipoDocument>(item)));

                }

            }
            catch (Exception ex)
            {

            }

            return output;
        }

        public Task<List<TipoDocumentos>> SelectAll()
        {
            throw new NotImplementedException();
        }



        public async Task <BaseOut> UpdateItem(UpdateTipoDocumentIn update)
        {
            var output = new BaseOut();
            

            try
            {
                _time.Start();

                var item = await _TipoDocumentoDAL.SelectItem(update.Id);

                if (item != null)
                {
                    item.CodigoProducto = update.CodigoProducto;
                    await _TipoDocumentoDAL.UpdateItem(item);
                    output.result = Result.Success;
                    output.message = "Operación Exitosa";
                }
                else
                {
                    output.result = Result.NoRecords;
                    output.message = "No hay datos";
                }
                output.StatusCode = HttpStatusCode.OK;
                _time.Stop();
                
            }
            catch (Exception ex)
            {
                output.result = Result.Error;
                output.message = "Error";
                output.StatusCode = HttpStatusCode.InternalServerError;
               
            }

            return output;
        }

    }
}
