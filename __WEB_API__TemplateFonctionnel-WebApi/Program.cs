using __WEB_API__TemplateFonctionnel_WebApi;
using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TemplateProjectDbContext>(
                    item => item.UseSqlServer("Server=SQLEXPRESS; Database=ECODING; Integrated Security=SSPI; "));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ITemplateFonctionnelRepository, TemplateFonctionnelRepository>();
builder.Services.AddScoped<ITemplateFonctionnelService, TemplateFonctionnelService>();

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "TemplateFonctionnelEntity",
        pattern: "{controller=TemplateFonctionnel}/{action=TemplateFonctionnelEntity}/{id}");

    endpoints.MapControllerRoute(
       name: "EditTemplateFonctionnelEntity",
       pattern: "{controller=TemplateFonctionnel}/{action=EditTemplateFonctionnelEntity}/{id}");

    endpoints.MapControllerRoute(
        name: "TemplateFonctionnelProperty",
        pattern: "{controller=TemplateFonctionnel}/{action=TemplateFonctionnelProperty}/{id}");

    endpoints.MapControllerRoute(
       name: "EditTemplateFonctionnelProperty",
       pattern: "{controller=TemplateFonctionnel}/{action=EditTemplateFonctionnelProperty}/{id}");

    endpoints.MapControllerRoute("TemplateFonctionnel", "{controller=TemplateFonctionnel}/{action=Index}/{id?}");
});