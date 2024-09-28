using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace STDem0.CustActionFilters
{
    public class ExceptionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult() { Content = "Exception Occured" };
            }
            base.OnActionExecuted(context);
        }
    }
}
