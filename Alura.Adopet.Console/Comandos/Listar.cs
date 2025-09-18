using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo da base de dados da AdoPet.")]
public class Listar : IComando
{
    private HttpClientPet _client;

    public Listar(HttpClientPet client)
    {
        this._client = client;
    }
    
    public async Task<Result> ExecutarAsync(string[] args)
    {
        return await this.Pets();
    }
    
    private async Task<Result> Pets()
    {
        var pets = await this._client.ListPetsAsync();
        foreach(Pet pet in pets)
        {
            System.Console.WriteLine(pet);
        }

        return Result.Ok();
    }
}