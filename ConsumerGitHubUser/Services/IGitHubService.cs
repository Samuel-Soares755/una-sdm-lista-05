using ConsumerGitHubUser.Models;

namespace ConsumerGitHubUser.Services;

public interface IGitHubService
{
    Task<GitHubUser?> GetUserAsync(int userId, CancellationToken cancellationToken = default);
}