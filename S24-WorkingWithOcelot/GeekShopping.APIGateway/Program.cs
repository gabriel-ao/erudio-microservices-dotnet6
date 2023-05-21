using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


#region CONFIGURAÇÂO DO CURSO DE ASPNET

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:4435";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
    };
});

builder.Services.AddOcelot();


#endregion 



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseOcelot();

app.Run();
