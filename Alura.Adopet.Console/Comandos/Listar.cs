using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo da base de dados da AdoPet.")]
public class Listar : IComando
{
    private HttpClientPet _client;

    public Listar()
    {
        this._client = new HttpClientPet();
    }
    
    public async Task ExecutarAsync(string[] args)
    {
        await this.Pets();
    }
    
    private async Task Pets()
    {
        var pets = await this._client.ListPetsAsync();
        foreach(Pet pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
}