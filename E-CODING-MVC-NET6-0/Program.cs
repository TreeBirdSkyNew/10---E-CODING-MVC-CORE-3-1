using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TemplateProjectDbContext>(
                    item => item.UseSqlServer("Server=SQLEXPRESS; Database=ECODING; Integrated Security=SSPI;"));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddHttpClient<ITemplateFonctionnelApiClient, TemplateFonctionnelApiClient>(clientFonctionnel =>
{
    clientFonctionnel.BaseAddress = new Uri("https://localhost:7073");
    clientFonctionnel.DefaultRequestHeaders.Clear();
    clientFonctionnel.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient<ITemplateResultApiClient, TemplateResultApiClient>(clientResult =>
{
    clientResult.BaseAddress = new Uri("https://localhost:7092");
    clientResult.DefaultRequestHeaders.Clear();
    clientResult.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient<ITemplateTechniqueApiClient, TemplateTechniqueApiClient>(clientTechnique =>
{
    clientTechnique.BaseAddress = new Uri("https://localhost:7132");
    clientTechnique.DefaultRequestHeaders.Clear();
    clientTechnique.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient<ITemplateProjectApiClient, TemplateProjectApiClient>(clientTechnique =>
{
    clientTechnique.BaseAddress = new Uri("https://localhost:7265");
    clientTechnique.DefaultRequestHeaders.Clear();
    clientTechnique.DefaultRequestHeaders.Add("Accept", "application/json");
});

/*
services.AddScoped<ITemplateResultApiClient, TemplateResultApiClient>();
services.AddScoped<ITemplateFonctionnelApiClient, TemplateFonctionnelApiClient>();
services.AddScoped<ITemplateTechniqueApiClient, TemplateTechniqueApiClient>();
services.AddScoped<ITemplateProjectApiClient, TemplateProjectApiClient>();
*/
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "TemplateProject",
    pattern: "{controller=TemplateProject}/{action=Index}/{id?}").WithMetadata(new AllowAnonymousAttribute());

app.MapControllerRoute(
    name: "TemplateFonctionnel",
    pattern: "{controller=TemplateFonctionnel}/{action=Index}/{id?}").WithMetadata(new AllowAnonymousAttribute());

app.MapControllerRoute(
    name: "TemplateResult",
    pattern: "{controller=TemplateResult}/{action=Index}/{id?}").WithMetadata(new AllowAnonymousAttribute());

app.MapControllerRoute(
    name: "TemplateTechnique",
    pattern: "{controller=TemplateTechnique}/{action=Index}/{id?}").WithMetadata(new AllowAnonymousAttribute());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TemplateTechnique}/{action=Index}/{id?}");

app.Run();


/**/