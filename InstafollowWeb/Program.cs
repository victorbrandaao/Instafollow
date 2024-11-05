using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel(serverOptions =>
                {
                    serverOptions.ListenAnyIP(5000); // Porta HTTP
                    serverOptions.ListenAnyIP(5001, listenOptions =>
                    {
                        listenOptions.UseHttps(); // Porta HTTPS
                    });
                });
            });
}