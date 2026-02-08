namespace Backend.Infra.Identity.Interfaces.Profile
{
    public interface IAuthentication
    {
        string? Hash { get; set; }
    }
}
