
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// uncommenting the code below would fix the issue
// app.Use(async (context, next) =>
// {
//     if (!context.Request.Path.Value!.Contains("."))
//     {
//         Console.WriteLine("hello");
//         var b = File.ReadAllText("./client/dist/index.html");
//         await context.Response.WriteAsync(b);
//     }
//     else
//     {
//         await next();
//     }
// }
//  );

app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "client/dist"))
    });
app.Run();
