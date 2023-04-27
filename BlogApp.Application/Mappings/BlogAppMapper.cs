using BlogApp.Application.Users.Requests;
using BlogApp.Application.Users.Responses;
using BlogApp.Domain.Users;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Application.Mappings;

public static class BlogAppMapper
{
    public static void AddMapster(this IServiceCollection services)
    {
        TypeAdapterConfig<UserRequestCreateModel, User>
            .NewConfig();

        TypeAdapterConfig<User, UserResponseModel>
            .NewConfig();
    }
}
