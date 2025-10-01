using Alura.Adopet.Console.Abstracoes;
using Alura.Adopet.Console.Modelo;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Utilitarios;

public class HttpClientPet : IApiService
{
    private HttpClient _httpClient;

    public HttpClientPet(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public virtual async Task<IEnumerable<Pet>?> ListAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
    
    public virtual async Task CreateAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            await _httpClient.PostAsJsonAsync("pet/add", pet);
        }
    }
}