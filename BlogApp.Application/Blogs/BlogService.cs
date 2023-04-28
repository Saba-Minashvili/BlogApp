using BlogApp.Application.Blogs.Requests;
using BlogApp.Application.Blogs.Responses;
using BlogApp.Application.Exceptions.Blogs;
using BlogApp.Application.Exceptions.Users;
using BlogApp.Domain.Abstractions;
using BlogApp.Domain.AuthorsBlogs;
using BlogApp.Domain.Blogs;
using BlogApp.Domain.Users;
using BlogApp.Infrastructure;
using BlogApp.Shared.Localizations.Culture.Resources;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Application.Blogs;

public class BlogService : IBlogService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BlogService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<BlogResponseModel>> GetAllBlogsAsync(CancellationToken cancellationToken = default)
    {
        var blogs = await _unitOfWork.BlogRepository.GetAllAsync(cancellationToken) ?? throw new BlogsNotFoundException(ErrorMessages.BlogsNotFoundException);

        return blogs.Adapt<IEnumerable<BlogResponseModel>>();
    }

    public async Task<IEnumerable<BlogResponseModel>> GetAllBlogsByUserIdAsync(CancellationToken cancellationToken = default)
    {
        var userId = GetUserIdFromJwtToken();

        var blogs = await _unitOfWork.BlogRepository.GetByUserIdAsync(userId, cancellationToken) ?? throw new BlogsNotFoundException(ErrorMessages.BlogsNotFoundException);

        return blogs.Adapt<IEnumerable<BlogResponseModel>>();
    }

    public async Task<BlogResponseModel> GetBlogByIdAsync(int blogId, CancellationToken cancellationToken = default)
    {
        var userId = GetUserIdFromJwtToken();

        await HasAccessToBlogAsync(blogId, userId, cancellationToken);

        var blog = await _unitOfWork.BlogRepository.GetByIdAsync(blogId, cancellationToken) ?? throw new BlogNotFoundException(ErrorMessages.BlogNotFoundException);

        return blog.Adapt<BlogResponseModel>();
    }

    public async Task<int> CreateBlogAsync(BlogRequestCreateModel request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var userId = GetUserIdFromJwtToken();

        var currentUser = await _unitOfWork.UserRepository.GetByIdAsync(userId, cancellationToken);

        // This line of code makes sure that every created blog
        // will have author which will be currently authorized user.
        var users = new List<User>() { currentUser };

        if (request.Authors.Any())
        {
            foreach (var authorEmail in request.Authors)
            {
                var exists = await _unitOfWork.UserRepository.ExistsAsync(o => o.Email.ToLower() == authorEmail.ToLower(), cancellationToken);

                if (!exists)
                    throw new EmailNotFoundException(ErrorMessages.EmailNotFoundException, authorEmail);

                if (authorEmail.ToLower() == currentUser.Email.ToLower())
                    continue;

                var user = await _unitOfWork.UserRepository.GetByEmailAsync(authorEmail, cancellationToken);

                users.Add(user);
            }
        }

        var blog = request.Adapt<Blog>();

        blog.Authors = users.Select(u => new AuthorBlog
        {
            User = u,
        }).ToArray();

        await _unitOfWork.BlogRepository.CreateAsync(blog, cancellationToken);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? blog.Id : throw new FailedToCreateBlogException(ErrorMessages.FailedToCreateBlogException);
    }

    public async Task<bool> UpdateBlogAsync(int blogId, BlogRequestUpdateModel request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        if (blogId == 0)
            throw new InvalidDataException(ErrorMessages.InvalidDataException);

        var exists = await _unitOfWork.BlogRepository.ExistsAsync(o => o.Id == blogId, cancellationToken);

        if (!exists)
            throw new BlogNotFoundException(ErrorMessages.BlogNotFoundException);

        var userId = GetUserIdFromJwtToken();

        await HasAccessToBlogAsync(blogId, userId, cancellationToken);

        var blog = await _unitOfWork.BlogRepository.GetByIdAsync(blogId, cancellationToken);

        blog.Id = blogId;
        blog.Title = request.Title;
        blog.Description = request.Description;
        blog.ModifiedAt = DateTime.Now;

        return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteBlogAsync(int blogId, CancellationToken cancellationToken = default)
    {
        if (blogId == 0)
            throw new InvalidDataException(ErrorMessages.InvalidDataException);

        var exists = await _unitOfWork.BlogRepository.ExistsAsync(o => o.Id == blogId, cancellationToken);

        if (!exists)
            throw new BlogNotFoundException(ErrorMessages.BlogNotFoundException);

        var userId = GetUserIdFromJwtToken();

        await HasAccessToBlogAsync(blogId, userId, cancellationToken);

        var blog = await _unitOfWork.BlogRepository.GetByIdAsync(blogId, cancellationToken);

        blog.Status = nameof(EntityStatus.Deleted);

        await _unitOfWork.AuthorBlogRepository.DeleteAuthorBlog(blog.Id, cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
    }

    private int GetUserIdFromJwtToken()
    {
        var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(o => o.Type == "UserId");

        return userIdClaim == null ? throw new UnauthorizedAccessException(ErrorMessages.UnauthorizedAccessException) : Convert.ToInt32(userIdClaim.Value);
    }

    private async Task<bool> HasAccessToBlogAsync(int blogId, int userId, CancellationToken cancellationToken = default)
    {
        var blog = await _unitOfWork.BlogRepository.GetByIdAsync(blogId, cancellationToken);

        var userIdExists = blog.Authors.Select(o => o.UserId).Contains(userId);

        if (!userIdExists)
            // It's better to throw not found exception
            // instead of saying that this kind of Blog exists and 
            // User has not access to it.
            throw new BlogNotFoundException(ErrorMessages.BlogNotFoundException);

        return true;
    }
}
