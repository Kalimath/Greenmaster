using FluentValidation.AspNetCore;
using Greenmaster.ArboretumWebService;
using Greenmaster.Core.Communication.Mail;
using Greenmaster.Core.Database;
using Greenmaster.Core.Database.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.RegisterAuthorization();
services.AddMailingService();
MailService.SetKey(builder.Configuration["MailApiKey"]);
services.AddMediatR(typeof(MediatrEntryPoint).Assembly);
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});
services.AddHttpContextAccessor();
services.AddMvc().AddFluentValidation(fv => fv.DisableDataAnnotationsValidation = false);
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//Register all Greenmaster.Core items (services, factories, EF and configuration)
services.RegisterGreenmasterCore(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();