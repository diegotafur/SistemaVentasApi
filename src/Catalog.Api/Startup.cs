using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Catalog.Api
{
    public class Startup
    {


        //se agrego para blazor
        readonly string MiCors = "MiCors";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //MvcOptions mvc = new MvcOptions();
            //mvc.EnableEndpointRouting = false;
            //services.AddMvc();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "www.aylluconsorcio.com",
                ValidAudience = "www.aylluconsorcio.com",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HGTSRAJUIROLPIUSJSHBVSRTEHSKJAJSHJAQWBGRDZXSYDPOKLDISSWASNDHSYT")),ClockSkew=TimeSpan.Zero
            });
            services.AddControllers();


            //se garego por blazor inicio
            services.AddCors(options =>
            {
                options.AddPolicy(name: MiCors,
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });
            //se garego por blazor fin

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MiCors); // se agrego por blazor

            app.UseAuthentication();


            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                    
                //    //await context.Response.WriteAsync("Hello World!");
                //});
            });

            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Default}/{action=Index}/{id?}");
            //});
            //ayllucorporacion.com/default/index/4
        }
    }
}
