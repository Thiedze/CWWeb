using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SelfHosted.Controller.V1;
using SelfHosted.Controller.V1.Authorizations;
using SelfHosted.Controller.V1.Authorizations.Domain;
using Service.Database;
using Service.SlushMachines;
using Service.Users;

namespace SelfHosted;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(typeof(MapperProfile).Assembly);

        services.AddSingleton<ISlushMachineService, SlushMachineService>();
        services.AddSingleton<IDatabaseService, SqLiteService>();
        services.AddSingleton<IUserService, UserService>();

        services.AddOptions<AppSettings>().Bind(Configuration.GetSection("AppSettings"));
        services.AddCors();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        IHostApplicationLifetime applicationLifetime)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        app.UseRouting();
        app.UseMiddleware<JwtMiddleware>();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}