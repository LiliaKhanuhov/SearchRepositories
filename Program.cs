using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using RepositoriesManager;


CreateHostBuilder(args).Build().Run();

static IWebHostBuilder CreateHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
