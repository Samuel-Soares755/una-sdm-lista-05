using System.Net.Http.Json;
using System.Text.Json.Serialization;

var httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Add("User-Agent", "ConsumerGitHubUserApp");

try
{
    var user = await httpClient.GetFromJsonAsync<GitHubUser>(
        "https://api.github.com/user/1");

    if (user is null)
    {
        Console.WriteLine("Usuário não encontrado.");
        return;
    }

    Console.WriteLine("===== Dados do Usuário GitHub =====\n");
    Console.WriteLine($"Nome: {user.Name}");
    Console.WriteLine($"Empresa: {user.Company}");
    Console.WriteLine($"Localização: {user.Location}");
    Console.WriteLine($"Login: {user.Login}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

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