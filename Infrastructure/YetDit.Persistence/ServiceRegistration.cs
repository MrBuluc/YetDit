using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Abstractions.Services.Authentications;
using YetDit.Application.Repositories.Comment;
using YetDit.Application.Repositories.Post;
using YetDit.Domain.Identity;
using YetDit.Persistence.Contexts;
using YetDit.Persistence.Repositories.Comment;
using YetDit.Persistence.Repositories.Post;
using YetDit.Persistence.Services;
using YetDit.Persistence.Services.AuthServices;

namespace YetDit.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<YetDitDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<YetDitDbContext>();

            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
            services.AddScoped<IPostReadRepository, PostReadRepository>();
            services.AddScoped<IPostWriteRepository, PostWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthentication, AuthService>();
        }
    }
}
