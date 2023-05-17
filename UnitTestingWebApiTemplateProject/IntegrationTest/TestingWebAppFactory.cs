using _4___E_CODING_DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTestingWebApiTemplateProject.IntegrationTest
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<TemplateProjectDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<TemplateProjectDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTemplateProjectTest");
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<TemplateProjectDbContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                        TestDbInitializer.TestDbContext();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            });
        }
    }
}
