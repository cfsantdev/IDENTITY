namespace Entities.Public.Interfaces
{
    public interface IProfile : IBaseNamedStateful
    {
        string Password { get; set; }
        string[] Role { get; set; }
    }
}
