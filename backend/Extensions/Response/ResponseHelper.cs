using BoleteriaOnline.Core.Extensions.Response;
using Microsoft.AspNetCore.Http;

namespace BoleteriaOnline.Web.Extensions.Response;
public static class ResponseHelper
{
    public static int GetHttpError(ErrorMessage gexError)
    {
        return gexError switch
        {
            ErrorMessage.Generic or ErrorMessage.CouldNotDelete or ErrorMessage.CouldNotDelete or ErrorMessage.CouldNotUpdate => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status200OK
        };
    }
}
