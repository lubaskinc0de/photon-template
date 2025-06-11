using Photon.Infrastructure;
using Photon.Web.Route;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Injector.Inject(builder);

var app = builder.Build();
app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.MapUser();
app.Run();
