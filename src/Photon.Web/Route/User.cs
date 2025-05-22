using Photon.Application.User;
using Photon.Application.User.Handler;

namespace Photon.Web.Route
{
    public static class UserRoute
    {
        public static void MapUser(this WebApplication app)
        {
            app.MapPost("/users", async (CreateUserDto dto, CreateUser handler) =>
            {
                var id = await handler.Handle(dto);
                return Results.Ok(new { Id = id });
            });
        }
    }
}