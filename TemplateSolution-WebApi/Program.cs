using AutoMapper;
using E_CODING_MVC_NET6_0;
using E_CODING_Service_Abstraction.Solution;
using E_CODING_Services.Solution;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using NLog;
using TemplateSolution_WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlServerContext();

builder.Services.AddScoped<ITemplateSolutionRepository, TemplateSolutionRepository>();
builder.Services.AddScoped<ISolutionRepositoryWrapper, SolutionRepositoryWrapper>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

