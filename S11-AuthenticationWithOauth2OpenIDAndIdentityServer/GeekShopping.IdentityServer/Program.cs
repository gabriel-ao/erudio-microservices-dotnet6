using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Initializer;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region CONFIGURAÇÂO DO CURSO DE ASPNET

// conexão ao banco de dados
ConfigurationManager configuration = builder.Configuration;

var connection = configuration["MySQLConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.
        UseMySql(connection,
            new MySqlServerVersion(
                new Version(8, 0, 5))));  // confirmar qual versão do MYSQL

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MySQLContext>()
    .AddDefaultTokenProviders();


builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddInMemoryClients(IdentityConfiguration.Clients)
    .AddAspNetIdentity<ApplicationUser>();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();


#endregion


var app = builder.Build();


#region SOLUÇÃO ALUNO 117 115 FINALIZANDO A IMPL.......

var initializer = app.Services.CreateScope().ServiceProvider.GetService<IDbInitializer>();


#endregion



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

#region CONFIGURAÇÂO DO CURSO DE ASPNET
app.UseHttpsRedirection();
#endregion

app.UseStaticFiles();

app.UseRouting();

#region CONFIGURAÇÂO DO CURSO DE ASPNET
app.UseIdentityServer();
#endregion

app.UseAuthorization();

#region CONFIGURAÇÂO DO CURSO DE ASPNET

//var initializer = app.Services.CreateScope().ServiceProvider.GetRequiredService<IDbInitializer>();

initializer.Initialize();

#endregion

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
