using Alura.Adopet.Console.Abstracoes;
using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Exibir : IComando
{
    private readonly ILeitorDeArquivo _leitorDeArquivo;

    public Exibir(ILeitorDeArquivo leitorDeArquivo)
    {
        _leitorDeArquivo = leitorDeArquivo;
    }

    public Task<Result> ExecutarAsync()
    {
        Result result;
        try
        {
            var listaDePets = this.ItensDoArquivo();
            result = Result.Ok().WithSuccess(new SucessoComPet(listaDePets, "Exibição do arquivo realizada com sucesso"));
        }
        catch (Exception ex)
        {
            result = Result.Fail(new Error("O camndo Exibição(show) falhou!").CausedBy(ex));
        }

        return Task.FromResult(result);
    }
    private IEnumerable<Pet> ItensDoArquivo()
    {
        var pets = _leitorDeArquivo.RealizarLeitura();
        return pets;
    }
}