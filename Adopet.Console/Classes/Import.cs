using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Adopet.Console.Classes;

public class Import
{
    private readonly HttpClient _client = ConfigureHttpClient("http://localhost:5057");

    public async Task FilePathToImportAsync(string filePathToImport)
    {
        var petList = new List<Pet>();
        using (var sr = new StreamReader(filePathToImport))
        {
            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[] propriedades = sr.ReadLine().Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    TipoPet.Cachorro
                );

                System.Console.WriteLine(pet);
                petList.Add(pet);
            }
        }

        foreach (var pet in petList)
        {
            try
            {
                var response = await CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        System.Console.WriteLine("Importação concluída!");
    }
    
    Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return _client.PostAsJsonAsync("pet/add", pet);
        }
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