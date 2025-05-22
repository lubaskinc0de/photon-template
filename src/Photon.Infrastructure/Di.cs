using Microsoft.Extensions.DependencyInjection;
using Photon.Application.User.Handler;
using Photon.Domain.Data;
using Photon.Domain.Repository;
using Photon.Infrastructure.Data;
using Photon.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Photon.Infrastructure
{
    public class AppDI
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=app.db"));

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IUoW, UoW>();
            services.AddScoped<CreateUser>();
        }
    }
}