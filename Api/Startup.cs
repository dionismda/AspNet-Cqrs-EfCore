using Domain.Entities;
using Domain.Handler;
using Domain.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers() ;
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database")) ;
            //services.AddDbContext<DataContext>(opt => opt.UseNpgsql("Database")) ;

            //services.AddTransient<ITodoRepository<Todo>, TodoRepository>() ;
            services.AddTransient<TodoHandler, TodoHandler>() ;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
