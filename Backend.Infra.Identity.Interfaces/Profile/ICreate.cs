namespace Backend.Infra.Identity.Interfaces.Profile
{
    public interface ICreate : Api.Crud.Interfaces.ICreate
    {
        Guid? OwnerId { get; set; }
        string? Password { get; set; }
        string[]? Role { get; set; }
    }
}
