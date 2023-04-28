using BlogApp.Application.Users.Responses;

namespace BlogApp.Application.Blogs.Responses;

public class BlogResponseModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IEnumerable<UserResponseModel> Authors { get; set; }
}
