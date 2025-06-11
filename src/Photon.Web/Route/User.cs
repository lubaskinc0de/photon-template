using Photon.Infrastructure.Adapter;
using Photon.Infrastructure.Service;

namespace Photon.Web.Route
{
    public static class UserRoute
    {
        public static void MapUser(this WebApplication app)
        {
            app.MapPost("/users", async (AuthUserCredentials dto, RegisterUser handler) =>
            {
                var id = await handler.HandleAsync(dto);
                return Results.Ok(new { Id = id });
            });
        }
    }
}