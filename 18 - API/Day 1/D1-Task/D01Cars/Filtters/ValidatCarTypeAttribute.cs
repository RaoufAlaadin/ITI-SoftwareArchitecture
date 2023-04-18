using D01Cars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace D01Cars.Filtters
{
    public class ValidatCarTypeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            car? car = context.ActionArguments["car"] as car;
            var Regex = new Regex("^(Electrical|Gas|Diesel|Hybrid)$",
                RegexOptions.IgnoreCase,
               TimeSpan.FromSeconds(2));
            if(car is null || !Regex.IsMatch(car.Type))
            {
                context.ModelState.AddModelError("Type", "Type Is Not Valid");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }


    }
}
