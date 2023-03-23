using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Services;
using E_CODING_Services.Project;
using Microsoft.EntityFrameworkCore;
using TemplateProject_WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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

builder.Services.AddScoped<ITemplateProjectRepository, TemplateProjectRepository>();
builder.Services.AddScoped<IProjectRepositoryWrapper, ProjectRepositoryWrapper>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }