using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private readonly string CorsPolicy = "CorsPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(CorsPolicy, policyBuilder=>
                {
                    policyBuilder.WithOrigins("hhtp://localhost:3000")
                    .AllowAnyHeader().AllowAnyMethod();
                });
            });
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        });
        }
        public void Configure(IApplicationBuilder application, IHostingEnvironment env){
            if (env.IsDevelopment()){
                application.UseDeveloperExceptionPage();
            } else {
                //app.UseHsts();
            }
        }
        AppContext.UseCors(CorsPolicy);
        app.UseMvc();
        }
    }
}
