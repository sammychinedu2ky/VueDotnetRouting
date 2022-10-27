using Microsoft.Extensions.FileProviders;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    // if the route doesn't have a file extension return the index.html
    if (!context.Request.Path.Value!.Contains("."))
    {
        var indexFile = File.ReadAllText("./client/dist/index.html");
        await context.Response.WriteAsync(indexFile);
    }
    else
    {
        await next();
    }
}
 );

app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "client/dist"))
    }
);
app.Run();
