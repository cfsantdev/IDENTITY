using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace Backend.Infra.Api.Crud.Interfaces
{
    public interface IControllerBase
    {
        HttpContext HttpContext { get; }
        HttpRequest Request { get; }
        HttpResponse Response { get; }
        RouteData RouteData { get; }
        ModelStateDictionary ModelState { get; }
        ControllerContext ControllerContext { get; set; }
        IModelMetadataProvider MetadataProvider { get; set; }
        IModelBinderFactory ModelBinderFactory { get; set; }
        IUrlHelper Url { get; set; }
        IObjectModelValidator ObjectValidator { get; set; }
        ClaimsPrincipal User { get; }

        StatusCodeResult StatusCode(int statusCode);
        ObjectResult StatusCode(int statusCode, object value);
        ContentResult Content(string content);
        ContentResult Content(string content, string contentType);
        ContentResult Content(string content, string contentType, Encoding contentEncoding);
        ContentResult Content(string content, MediaTypeHeaderValue contentType);
        NoContentResult NoContent();
        OkResult Ok();
        OkObjectResult Ok(object value);
        UnauthorizedResult Unauthorized();
        UnauthorizedObjectResult Unauthorized(object value);
        NotFoundResult NotFound();
        NotFoundObjectResult NotFound(object value);
        BadRequestResult BadRequest();
        BadRequestObjectResult BadRequest(object error);
        BadRequestObjectResult BadRequest(ModelStateDictionary modelState);
        UnprocessableEntityResult UnprocessableEntity();
        UnprocessableEntityObjectResult UnprocessableEntity(object error);
        UnprocessableEntityObjectResult UnprocessableEntity(ModelStateDictionary modelState);
        ConflictResult Conflict();
        ConflictObjectResult Conflict(object error);
        ConflictObjectResult Conflict(ModelStateDictionary modelState);
        ActionResult ValidationProblem(ValidationProblemDetails descriptor);
        ActionResult ValidationProblem(ModelStateDictionary modelStateDictionary);
        ActionResult ValidationProblem();
        CreatedResult Created(string uri, object value);
        CreatedResult Created(Uri uri, object value);
        CreatedAtActionResult CreatedAtAction(string actionName, object value);
        CreatedAtActionResult CreatedAtAction(string actionName, object routeValues, object value);
        CreatedAtActionResult CreatedAtAction(string actionName, string controllerName, object routeValues, object value);
        CreatedAtRouteResult CreatedAtRoute(string routeName, object value);
        CreatedAtRouteResult CreatedAtRoute(object routeValues, object value);
        CreatedAtRouteResult CreatedAtRoute(string routeName, object routeValues, object value);
        AcceptedResult Accepted();
        AcceptedResult Accepted(object value);
        AcceptedResult Accepted(Uri uri);
        AcceptedResult Accepted(string uri);
        AcceptedResult Accepted(string uri, object value);
        AcceptedResult Accepted(Uri uri, object value);
        AcceptedAtActionResult AcceptedAtAction(string actionName);
        AcceptedAtActionResult AcceptedAtAction(string actionName, string controllerName);
        AcceptedAtActionResult AcceptedAtAction(string actionName, object value);
        AcceptedAtActionResult AcceptedAtAction(string actionName, string controllerName, object routeValues);
        AcceptedAtActionResult AcceptedAtAction(string actionName, object routeValues, object value);
        AcceptedAtActionResult AcceptedAtAction(string actionName, string controllerName, object routeValues,  object value);
        AcceptedAtRouteResult AcceptedAtRoute(object routeValues);
        AcceptedAtRouteResult AcceptedAtRoute(string routeName);
        AcceptedAtRouteResult AcceptedAtRoute(string routeName, object routeValues);
        AcceptedAtRouteResult AcceptedAtRoute(object routeValues, object value);
        AcceptedAtRouteResult AcceptedAtRoute(string routeName, object routeValues, object value);
        ChallengeResult Challenge();
        ChallengeResult Challenge(params string[] authenticationSchemes);
        ChallengeResult Challenge(AuthenticationProperties properties);
        ChallengeResult Challenge(AuthenticationProperties properties, params string[] authenticationSchemes);
        ForbidResult Forbid();
        ForbidResult Forbid(params string[] authenticationSchemes);
        ForbidResult Forbid(AuthenticationProperties properties);
        ForbidResult Forbid(AuthenticationProperties properties, params string[] authenticationSchemes);
        SignInResult SignIn(ClaimsPrincipal principal, string authenticationScheme);
        SignInResult SignIn(ClaimsPrincipal principal, AuthenticationProperties properties, string authenticationScheme);
        SignOutResult SignOut(params string[] authenticationSchemes);
        SignOutResult SignOut(AuthenticationProperties properties, params string[] authenticationSchemes);
        Task<bool> TryUpdateModelAsync<TModel>(TModel model) where TModel : class;
        Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix) where TModel : class;
        Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, IValueProvider valueProvider) where TModel : class;
        Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, params Expression<Func<TModel, object>>[] includeExpressions) where TModel : class;
        Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, Func<ModelMetadata, bool> propertyFilter) where TModel : class;
        Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, IValueProvider valueProvider, params Expression<Func<TModel, object>>[] includeExpressions) where TModel : class;
        Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, IValueProvider valueProvider, Func<ModelMetadata, bool> propertyFilter) where TModel : class;
        Task<bool> TryUpdateModelAsync(object model, Type modelType, string prefix);
        Task<bool> TryUpdateModelAsync(object model, Type modelType, string prefix, IValueProvider valueProvider, Func<ModelMetadata, bool> propertyFilter);
        bool TryValidateModel(object model);
        bool TryValidateModel(object model, string prefix);
    }
}
