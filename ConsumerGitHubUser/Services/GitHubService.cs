using System.Net.Http.Json;
using ConsumerGitHubUser.Models;

namespace ConsumerGitHubUser.Services;

public sealed class GitHubService(HttpClient httpClient) : IGitHubService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<GitHubUser?> GetUserAsync(int userId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"https://api.github.com/user/{userId}";

        using var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

        // GitHub exige User-Agent
        request.Headers.Add("User-Agent", "ConsumerGitHubUserApp");

        using var response = await _httpClient.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"Erro ao consumir API do GitHub. Status Code: {response.StatusCode}");
        }

        return await response.Content.ReadFromJsonAsync<GitHubUser>(cancellationToken: cancellationToken);
    }
}