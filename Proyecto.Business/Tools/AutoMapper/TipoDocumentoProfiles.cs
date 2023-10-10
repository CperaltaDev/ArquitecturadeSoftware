using AutoMapper;
using Proyecto.Data.Dto;
using Proyecto.Data.Entities;

namespace Proyecto.Business.Tools.AutoMapper
{
    public class TipoDocumentoProfiles : Profile
    {
        public TipoDocumentoProfiles()
        {
            CreateMap<TipoDocumentos, TipoDocument>().ReverseMap();
            CreateMap<DocumentoIn, Documentos>().ReverseMap();
            CreateMap<DocumentoOut, Documentos>().ReverseMap();

        }
    }
}
