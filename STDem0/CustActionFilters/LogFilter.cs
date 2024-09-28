using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace STDem0.CustActionFilters
{
    public class LogFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("action start");
            base.OnActionExecuting(context);
        }
    }
}
