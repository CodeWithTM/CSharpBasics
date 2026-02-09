using CoreWebMinimalAPIs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

Endpoints.MapEndpoints(app);


app.Run();



// In ASP.NET Core Minimal APIs, you don't need to explicitly use middleware like `UseRouting` because
// the framework automatically handles routing for you when you define your endpoints using methods like `MapGet`, `MapPost`, etc.
// The routing is built into the endpoint definitions, so when you call `app.MapGet("/weather", ...)`,
// it sets up the necessary routing internally without requiring additional middleware configuration.
// This simplifies the setup and allows you to focus on defining your endpoints directly.

// List down differences between ASP.NET Core Minimal APIs and traditional Controller
// 1. **Simplicity**: Minimal APIs are designed to be simple and straightforward, allowing developers to define endpoints directly in the `Program.cs` file without the need for controllers, actions, or attributes. Traditional controllers require more structure and boilerplate code.
// 2. **Routing**: In Minimal APIs, routing is defined directly on the endpoint methods (e.g., `app.MapGet("/weather", ...)`), while in traditional controllers, routing is typically defined using attributes (e.g., `[Route("api/[controller]")]`) or convention-based routing in the `Startup.cs` file.
// 3. **Dependency Injection**: Minimal APIs allow for direct injection of services into the endpoint methods, while traditional controllers rely on constructor injection to access services.
// 4. **Response Handling**: Minimal APIs return responses directly from the endpoint methods, while traditional controllers often return `IActionResult` or specific result types (e.g., `JsonResult`, `ViewResult`) to control the response format and status codes.
// 5. **Middleware**: Minimal APIs can be more lightweight and may not require as much middleware configuration as traditional controllers, which often rely on middleware for features like authentication, authorization, and model binding.
// 6. **Use Cases**: Minimal APIs are ideal for simple applications, microservices, or when you want to quickly define a few endpoints without the overhead of a full MVC structure. Traditional controllers are better suited for larger applications with complex business logic and multiple endpoints that benefit from the organization provided by controllers and actions.



