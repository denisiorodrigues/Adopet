using Alura.Adopet.Console.Abstracoes;
using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo da base de dados da AdoPet.")]
public class Listar : IComando
{
    private IApiService _client;

    public Listar(IApiService client)
    {
        this._client = client;
    }
    
    public async Task<Result> ExecutarAsync()
    {
        return await this.Pets();
    }
    
    private async Task<Result> Pets()
    {
        try
        {
            var pets = await this._client.ListAsync();
            return Result.Ok().WithSuccess(new SucessoComPet(pets));
        }
        catch (Exception ex)
        {
           return Result.Fail(new Error("Não foi possível obter a lista de pets.").CausedBy(ex));
        }
    }
}