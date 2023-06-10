using System.Text.Json.Serialization;
using Greenmaster.Core.Configuration;
using Greenmaster.Core.Database.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// services.AddEndpointsApiExplorer();
// services.AddSwaggerGen();

//Register all Greenmaster.Core items (services, factories, EF and configuration)
services.RegisterGreenmasterCore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
    /*app.UseSwagger();
    app.UseSwaggerUI();*/
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Specie}/{action=Index}/{id?}");

app.Run();