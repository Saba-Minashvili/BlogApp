using BlogApp.Application.Blogs.Requests;
using BlogApp.Application.Blogs.Responses;
using BlogApp.Application.Users.Requests;
using BlogApp.Application.Users.Responses;
using BlogApp.Domain.AuthorsBlogs;
using BlogApp.Domain.Blogs;
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

        TypeAdapterConfig<BlogRequestCreateModel, Blog>
            .NewConfig()
            .Ignore(o => o.Authors);

        TypeAdapterConfig<BlogRequestUpdateModel, Blog>
            .NewConfig();

        TypeAdapterConfig<Blog, BlogResponseModel>
            .NewConfig();

        TypeAdapterConfig<AuthorBlog, UserResponseModel>
            .NewConfig()
            .Map(dest => dest.Id, src => src.User.Id)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName);
    }
}
