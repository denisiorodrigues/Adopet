using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Utilitarios;

public class HttpClientPet
{
    private HttpClient _httpClient;

    public HttpClientPet(string uri = "http://localhost:5057")
    {
        _httpClient = this.ConfiguraHttpClient(uri);
    }
    
    private HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }

    public async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
    
    public async Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return await _httpClient.PostAsJsonAsync("pet/add", pet);
        }
    }
}