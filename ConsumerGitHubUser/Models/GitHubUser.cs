using System.Text.Json.Serialization;

namespace ConsumerGitHubUser.Models;

public sealed class GitHubUser
{
    [JsonPropertyName("login")]
    public string? Login { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("company")]
    public string? Company { get; init; }

    [JsonPropertyName("location")]
    public string? Location { get; init; }
}