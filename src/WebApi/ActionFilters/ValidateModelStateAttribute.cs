using CarDataPlatformIngestor.Application.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace WebApi.ActionFilters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var failures = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToList();

                if (failures.Count > 0)
                {
                    throw new ValidationException(failures);
                }
            }
        }
    }
}
