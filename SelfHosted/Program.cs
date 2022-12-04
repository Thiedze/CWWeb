using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SelfHosted;

public static class Program
{
    public static void Main(string[] args)
    {
        var baseUrls = new[] {"http://*:7041"};
        CreateHostBuilder(args, baseUrls, 7042).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args, string[] baseUrls, int httpsPort)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseSetting("https_port", httpsPort.ToString());
                webBuilder.UseUrls(baseUrls);
                webBuilder.UseStartup<Startup>();
                webBuilder.GetSetting("AppSettings");
            });
    }
}