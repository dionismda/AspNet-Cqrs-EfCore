using Domain.Entities;
using Domain.Handler;
using Domain.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
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
            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database")) ;
            services.AddDbContext<DataContext>(opt => 
                    opt.UseNpgsql(Configuration.GetConnectionString("ConnectionStrings"))
            ) ;

            services.AddTransient<ITodoRepository<Todo>, TodoRepository>();
            services.AddTransient<TodoHandler>();

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
