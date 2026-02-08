namespace Backend.Infra.Api.Crud.Interfaces
{
    public interface ICreateRel
    {
        Guid CoverId { get; set; }
        Guid RelatedId { get; set; }
    }
}
