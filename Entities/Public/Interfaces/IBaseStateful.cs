namespace Entities.Public.Interfaces
{
    public interface IBaseStateful : IBase
    {
        bool State { get; set; }
    }
}
