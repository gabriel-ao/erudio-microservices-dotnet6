using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);


#region CONFIGURAÇÂO DO CURSO DE ASPNET

builder.Services.AddHttpClient<IProductService, ProductService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"]));

#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
