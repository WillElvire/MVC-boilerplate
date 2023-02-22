using WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureLogging(logging =>
            {
                /*logging.AddEventLog(eventLogSettings =>
                {
                    eventLogSettings.SourceName = "API_INTERNE";
                });*/
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}