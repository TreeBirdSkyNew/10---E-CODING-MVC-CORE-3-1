using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using Microsoft.EntityFrameworkCore;
using TemplateTechnique_WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TemplateProjectDbContext>(
                    item => item.UseSqlServer("Server=SQLEXPRESS; Database=ECODING; Integrated Security=SSPI; "));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ITemplateTechniqueRepository, TemplateTechniqueRepository>();
builder.Services.AddScoped<ITemplateTechniqueService, TemplateTechniqueService>();


var app = builder.Build();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();