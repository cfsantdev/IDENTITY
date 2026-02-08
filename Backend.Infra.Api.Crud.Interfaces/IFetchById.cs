namespace Backend.Infra.Api.Crud.Interfaces
{
    public interface IFetchById
    {
        Guid Id { get; set; }
        Guid PublisherId { get; set; }
    }
}
