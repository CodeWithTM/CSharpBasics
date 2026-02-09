using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace COREWebAPI.Controllers
{

    // Synchronous vs Asynchronous Filters in ASP.NET Core
    // Synchronous filters are executed in a blocking manner, meaning that the thread executing the filter will be blocked
    // until the filter completes its work. This can lead to performance issues if the filter performs long-running operations,
    // such as database calls or external API requests.
    // Asynchronous filters, on the other hand, allow for non-blocking execution.
    // They can perform long-running operations without blocking the thread, which can improve the responsiveness
    // of the application. Asynchronous filters are typically implemented using the IAsyncActionFilter interface,
    // which provides an asynchronous method for executing the filter logic.

    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        [CustomFilter]
        public string Get()
        {
            return "Account controller";
        }
    }

    public class CustomFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        public override async void OnActionExecuting(ActionExecutingContext context)
        {

            await Task.Delay(5000);

            // This code runs before the action executes
            Console.WriteLine("CustomFilter: Before executing action.");

            
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // This code runs after the action executes
            Console.WriteLine("CustomFilter: After executing action.");
        }
    }

    public class CustomAsyncFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await Task.Delay(5000); // Simulate some asynchronous work before the action executes

            Console.WriteLine("Async CustomFilter: Before executing action.");

            await next(); // Call the next delegate/middleware in the pipeline

            Console.WriteLine("Async CustomFilter: After executing action.");
        }
    }
}
