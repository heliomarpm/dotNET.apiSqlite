using MyTodo;

//var builder = WebApplication.CreateBuilder(args);

//var startup = new Startup(builder.Configuration);
//startup.ConfigurationServices(builder.Services);

//var app = builder.Build();

////app.MapGet("/", () => "Hello World!");
//startup.Configure(app, app.Environment);
//app.Run();


WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();