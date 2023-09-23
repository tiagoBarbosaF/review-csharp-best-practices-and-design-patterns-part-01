using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Adopet.Console.Classes;

public class List
{
    private readonly HttpClient _client = ConfigureHttpClient("http://localhost:5057");

    public async Task ListAllPetsAsync()
    {
        var pets = await ListPetsAsync();
        foreach (var pet in pets) System.Console.WriteLine(pet);
    }
    
    async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        var response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
    
    private static HttpClient ConfigureHttpClient(string url)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        client.BaseAddress = new Uri(url);
        return client;
    }
}