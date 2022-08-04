using BudgetControl.Api.Bootstrap;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseKestrel()
        .UseStartup<Startup>()
        .UseUrls("http://+:5104");
    });


var app = builder.Build();
app.Run();