using Microsoft.Extensions.DependencyInjection;
using Photon.Domain.Data;
using Photon.Domain.Repository;
using Photon.Infrastructure.Data;
using Photon.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Photon.Infrastructure.Adapter;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Photon.Application.User.Handler;

namespace Photon.Infrastructure
{
    public class Injector
    {
        public static void Inject(IHostApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection")
            ));

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IUoW, UoW>();
            services.AddSingleton<IPasswordHasher, IdentityPasswordHasher>();
            services.AddScoped<AuthUserRepo>();
            services.AddScoped<CreateUser>();
        }
    }
}