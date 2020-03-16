using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Db.Context;
using Db.Repository;
using Db.Repository.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TurPoengAPI
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
            services.AddDbContext<TurPoengContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });


            /*  services.AddDbContext<PersonContext>(opt =>
              opt.UseInMemoryDatabase("PersonList"));

              services.AddDbContext<IdrettslagContext>(opt =>
              opt.UseInMemoryDatabase("PersonList"));

              services.AddDbContext<PosterContext>(opt =>
          opt.UseInMemoryDatabase("PersonList"));
          s
              */
            /* Turer to be appended*/
            /*
            services.AddDbContext<TurerContext>(opt =>
        opt.UseInMemoryDatabase("PersonList"));
        */
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IIdrettslagRepository, IdrettslagRepository>();
            services.AddTransient<IPostRepository, PostRepository>();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Person}/{action=Get}/{id?}");

                //endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "vedlegg",
                //    pattern: "Vedlegg/{formId}/{formSecret}");
            });
        }
    }
}
