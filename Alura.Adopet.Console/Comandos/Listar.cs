using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Atributos;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo da base de dados da AdoPet.")]
public class Listar : IComando
{
    private HttpClient _client;

    public Listar()
    {
        this._client = ConfiguraHttpClient("http://localhost:5057");
    }
    
    public async Task ExecutarAsync(string[] args)
    {
        await this.Pets();
    }
    
    private async Task Pets()
    {
        var pets = await ListPetsAsync();
        foreach(Pet pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
    
    HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
    
    private async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}