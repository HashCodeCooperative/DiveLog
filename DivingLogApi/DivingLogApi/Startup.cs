using AutoMapper;
using DivingLogApi.Data;
using DivingLogApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using Microsoft.OpenApi.Models; 

namespace DivingLogApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                                  {
                                      builder.WithOrigins("*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod(); ;
                                  });
            }); 
             
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DivingLogApi", Version = "v1" });
            });
              
            services.AddDbContext<DivingLogContext>(options =>
                    options.UseSqlite("Data Source=Data/DivingLogDb.db"));

            

            services.AddControllersWithViews() 
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<UserService>();
            services.AddTransient<DiveService>();
            services.AddTransient<DiveSiteService>();
            services.AddTransient<UserDiveService>();
            services.AddTransient<IAuthorizationServices, AuthorizationServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DivingLogApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
           // app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}