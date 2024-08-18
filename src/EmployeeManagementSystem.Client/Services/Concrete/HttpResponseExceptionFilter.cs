using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Client.Services.Concrete
{
    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is HttpRequestException httpRequestException &&
                httpRequestException.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                context.Result = new RedirectToActionResult("UnauthorizedAccess", "Home", null);
                context.ExceptionHandled = true;
            }
        }
    }
}
