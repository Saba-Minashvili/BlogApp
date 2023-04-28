using BlogApp.Application.Blogs.Requests;
using BlogApp.Application.Blogs.Responses;

namespace BlogApp.Application.Blogs;

public interface IBlogService
{
    Task<IEnumerable<BlogResponseModel>> GetAllBlogsAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<BlogResponseModel>> GetAllBlogsByUserIdAsync(CancellationToken cancellationToken = default);

    Task<BlogResponseModel> GetBlogByIdAsync(int blogId, CancellationToken cancellationToken = default);

    Task<int> CreateBlogAsync(BlogRequestCreateModel request, CancellationToken cancellationToken = default);

    Task<bool> UpdateBlogAsync(int blogId, BlogRequestUpdateModel request, CancellationToken cancellationToken = default);

    Task<bool> DeleteBlogAsync(int blogId, CancellationToken cancellationToken = default);
}
