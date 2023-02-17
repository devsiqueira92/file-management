using FileManagement.Shared.Communication.Responses;
using FileManagement.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace FileManagement.API.Filters;

public class ExceptionFilters : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseException)
            ResolveBaseExceptions(context);

        else
            ThrowUnknowError(context);
    }

    private void ResolveBaseExceptions(ExceptionContext context)
    {
        if (context.Exception is ValidationErrorsExceptions)
            ResolveValidationErrorsExcpetions(context);
    }

    private void ResolveValidationErrorsExcpetions(ExceptionContext context)
    {
        var errorValidation = context.Exception as ValidationErrorsExceptions;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new ErrorResponse(errorValidation.ErrorsMesssages));
    }


    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ErrorResponse(ResourceErrorsMessage.UNKNOW_ERROR));
    }
}
