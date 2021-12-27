using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InsuranceAdvisor.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.GetErrors();
                context.Result = new BadRequestObjectResult(errors);
            }

        }
    }

    public static class ModelStateExtensions
    {
        public static IList<string> GetErrors(this ModelStateDictionary modelState)
        {
            return modelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
        }
    }
}
