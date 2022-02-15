using BoleteriaOnline.Core.Extensions;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Middlewares;
public static class BadRequestMiddleware
{
    public static IMvcBuilder AddBadRequestServices(this IMvcBuilder services)
    {
        services.ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var modelState = actionContext.ModelState;

                return new OkObjectResult(new WebResult<object>
                {
                    Result = null,
                    ErrorCode = ErrorMessage.GenericValidation,
                    ErrorMessages = actionContext.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => new string(kvp.Key.ToSnakeCase().ToArray()),
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    ),
                    Success = false,
                    Message = ErrorMessage.GenericValidation.GetDescription()
                }); ;
            };
        });
        return services;
    }
}
