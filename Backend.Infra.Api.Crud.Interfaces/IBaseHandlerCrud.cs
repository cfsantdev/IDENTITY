using Microsoft.AspNetCore.Mvc;

namespace Backend.Infra.Api.Crud.Interfaces
{
    public interface IBaseHandlerCrud<TController, TContext, TEntity, TEntityDTO>
    {
        Task<IActionResult> FetchAsync();
        Task<IActionResult> FetchByIdAsync(IFetchById filtro);
        Task<IActionResult> FetchByNameAsync(IFetchByName filtro);
        Task<IActionResult> CreateAsync<TEntityCreate>(TEntityCreate command);
        Task<IActionResult> UpdateAsync<TEntityUpdate>(TEntityUpdate command);
        Task<IActionResult> DeleteByIdAsync(IFetchById filtro);
        Task<IActionResult> ChangeStateByIdAsync(IFetchById filtro);
        Guid? PublisherIdentifier(string publisher);
    }
}
