using COREWebAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


//we can test the JSON token created using below command
//dotnet user-jwts create 
builder.Services.AddAuthentication().AddJwtBearer();
    /*AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false, // Set to true and configure if you want to validate
            ValidateAudience = false, // Set to true and configure if you want to validate
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false
        };
    });*/

builder.Services.AddAuthorization();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof( CustomAsyncFilter));
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(_ => { });


// Example protected endpoint
app.MapGet("/secure", (HttpContext ctx) =>
{
    return $"Hello, {ctx.User.Identity?.Name ?? "unknown"}! Your JWT is valid.";
}).RequireAuthorization();

app.MapControllers();

app.Run();
