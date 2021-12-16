using ABAUfaBot.Application;
using ABAUfaBot.Application.Common.Mappings;
using ABAUfaBot.Application.Factories;
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.WebApi;
using ABAUfaBot.WebAPI.Extensions;
using ABAUfaBot.WebAPI.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ABAUfaBot.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IABAGoogleTableService).Assembly));
            });
            services.AddControllers();
            services.AddApplication();
            services.AddVersionedApiExplorer(options =>
                options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
                    ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            services.AddApiVersioning();

            services.AddSingleton<IAdminOptions>(g => Configuration.GetSection(nameof(AdminOptions)).Get<AdminOptions>());
            services.SetupGoogleTables(Configuration);
            services.AddSingleton<ISendMessageFactory, SendMessageFactory>();
            services.AddSingleton<IBotCommandFactory, BotCommandFactory>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    config.RoutePrefix = string.Empty;
                }
            });

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseApiVersioning();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
