using GarphQL.tutorial.Data;
using GarphQL.tutorial.GraphQL;
using voyager = GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GarphQL.tutorial.GraphQL.Platforms;
using GarphQL.tutorial.GraphQL.Commands;

namespace GarphQL.tutorial
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

            //services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GarphQL.tutorial", Version = "v1" });
            //});

            services.AddPooledDbContextFactory<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services
                .AddGraphQLServer()
                     .AddQueryType<QueryTest>()
                     .AddMutationType<Mutation>()
                     .AddSubscriptionType<Subscription>()
                     .AddType<PlatformType>()
                     .AddType<CommandType>()
                     .AddFiltering()
                     .AddSorting()
                     .AddProjections()
                     .AddInMemorySubscriptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //    app.UseSwagger();
                //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GarphQL.tutorial v1"));
            }

            //app.UseHttpsRedirection();
            app.UseWebSockets();
            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new voyager.VoyagerOptions
            {
                GraphQLEndPoint = "/graphql"
            }, path: "/graphql-voyager");
        }
    }
}
