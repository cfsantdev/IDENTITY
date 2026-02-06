using AutoMapper;
using Backend.Infra.Identity.Documents.Document;
using Backend.Infra.Identity.Documents.DocumentType;
using Backend.Infra.Identity.DTO.Documents;
using Backend.Infra.Identity.DTO.Documents.DocumentType;
using Backend.Infra.Identity.DTO.Interfaces.Documents;
using Backend.Infra.Identity.Interfaces.Documents;

namespace Backend.Infra.Identity.Extensions.AutoMapper
{
    public class DocumentExtension : Backend.Infra.Extensions.AutoMapperTools.AutoMapperExtension, Backend.Infra.Extensions.AutoMapperTools.IAutoMapperExtension
    {
        public override void AddAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ICreateDocument, IDocument>().ReverseMap();
            cfg.CreateMap<IDocumentDTO, IDocument>().ReverseMap();
            cfg.CreateMap<IUpdateDocument, IDocument>().ReverseMap();

            cfg.CreateMap<CreateDocument, Document>().ReverseMap();
            cfg.CreateMap<DocumentDTO, Document>().ReverseMap();
            cfg.CreateMap<UpdateDocument, Document>().ReverseMap();
        }
    }
}
