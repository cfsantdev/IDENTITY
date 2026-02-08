using AutoMapper;
using Backend.Infra.Identity.Documents.DocumentType;
using Backend.Infra.Identity.DTO.Documents.DocumentType;
using Backend.Infra.Identity.DTO.Interfaces.Documents.DocumentTypes;
using Backend.Infra.Identity.Interfaces.Documents.DocumentType;
using Backend.Infra.Identity.Interfaces.Session;
using Backend.Infra.Identity.Session;

namespace Backend.Infra.Identity.Extensions.AutoMapper
{
    public class DocumentTypeExtension : Backend.Infra.Extensions.AutoMapperTools.AutoMapperExtension, Backend.Infra.Extensions.AutoMapperTools.IAutoMapperExtension
    {
        public override void AddAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ICreateDocumentType, IDocumentType>().ReverseMap();
            cfg.CreateMap<IDocumentTypeDTO, IDocumentType>().ReverseMap();
            cfg.CreateMap<IUpdateDocumentType, IDocumentType>().ReverseMap();

            cfg.CreateMap<CreateDocumentType, DocumentType>().ReverseMap();
            cfg.CreateMap<DocumentTypeDTO, DocumentType>().ReverseMap();
            cfg.CreateMap<UpdateDocumentType, DocumentType>().ReverseMap();
        }
    }
}
