﻿using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Adopet.Console.Classes;

[DocCommand(instruction: "import",documentation: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import
{
    private readonly HttpClient _client = ConfigureHttpClient("http://localhost:5057");

    public async Task FilePathToImportAsync(string filePathToImport)
    {
        var petList = new LeitorArquivo().LerArquivo(filePathToImport);

        foreach (var pet in petList)
        {
            System.Console.WriteLine(pet);
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