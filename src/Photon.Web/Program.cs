using Photon.Infrastructure;
using Photon.Web.Route;

var builder = WebApplication.CreateBuilder(args);
Injector.Inject(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/swagger/swagger.json", "Photon API"); });
}

app.MapUser();
app.Run();
