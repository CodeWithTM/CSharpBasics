namespace CoreWebMinimalAPIs
{
    internal class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
    public static class Endpoints
    {

        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            var summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            app.MapGet("/weather", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                               new WeatherForecast
                                              (
                                                      DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                                                                         Random.Shared.Next(-20, 55),
                                                                                            summaries[Random.Shared.Next(summaries.Length)]
                                                                                                           ))
                    .ToArray();
                return forecast;
            }).RequireAuthorization();

            app.MapGet("/", () =>
            { 
                return "Hello World!";
            });

            app.MapGet("/hello", () => "Hello from the /hello endpoint!");

            app.MapGet("/product/{id}", (int id) => $"Product ID: {id}");

            app.MapPost("/product", (Product product) => $"Received product: {product.Name} with price {product.Price}");
        }
    }
}
