using Alura.Adopet.Console.Abstracoes;
using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Importar : IComando
{
    private readonly IApiService<Pet> _client;
    private readonly ILeitorDeArquivo _leitorDeArquivo;

    public Importar(IApiService<Pet> client, ILeitorDeArquivo leitorDeArquivo)
    {
        _client = client;
        _leitorDeArquivo = leitorDeArquivo;
    }

    public async Task<Result> ExecutarAsync()
    {
        return await this.ArquivoPetAsync();
    }

    private async Task<Result> ArquivoPetAsync()
    {
        try
        {
            var listaDePets = _leitorDeArquivo.RealizarLeitura();

            foreach (Pet pet in listaDePets)
            {
                await _client.CreateAsync(pet);
            }

            return Result.Ok().WithSuccess(new SucessoComPet(listaDePets, "\nImportação realizada com sucesso.\n"));
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
        }
    }
}