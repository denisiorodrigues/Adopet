using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Utilitarios;

public class HttpClientPet
{
    private HttpClient _httpClient;

    public HttpClientPet(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public virtual async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
    
    public virtual async Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return await _httpClient.PostAsJsonAsync("pet/add", pet);
        }
    }
}