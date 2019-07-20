using BP.Models.Shared.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Domain.Shared.Attributes
{
    public class ValidateNotationAttribute : ActionFilterAttribute
    {
        //public virtual Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{

        //    return Task.Run(() => Console.Write("A"));

        //}

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.ModelState.IsValid) return;

            var errors = new Dictionary<string, IEnumerable<string>>();

            foreach (var item in context.ModelState.Where(p => p.Value.ValidationState == ModelValidationState.Invalid))
            {
                var key = item.Key;
                var messages = item.Value.Errors.Select(p => p.Exception?.Message ?? p.ErrorMessage);
                errors.Add(key, messages);
            }

            context.HttpContext.Response.StatusCode = 422;
            context.Result = new ObjectResult(
                errors.Select(p => new ValidationResponseModel()
                {
                    Property = p.Key,
                    Errors = p.Value.ToArray()
                })
            );
        }

    }
}
