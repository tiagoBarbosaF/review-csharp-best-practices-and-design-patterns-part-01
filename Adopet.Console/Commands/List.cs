using System.Net.Http.Headers;
using System.Net.Http.Json;
using Adopet.Console.Classes;

namespace Adopet.Console.Commands;

[DocCommand(instruction: "list",
    documentation: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da Adopet.")]
public class List : ICommand
{
    private readonly HttpClient _client = ConfigureHttpClient("http://localhost:5057");

    public async Task ExecuteAsync(string[] args)
    {
        var pets = await ListPetsAsync();
        foreach (var pet in pets!) System.Console.WriteLine(pet);
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