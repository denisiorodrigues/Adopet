using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Exibir : IComando
{
    public Task<Result> ExecutarAsync(string[] args)
    {
        Result result;
        try
        {
            var listaDePets = this.ItensDoArquivo(caminhoDoArquivoASerExibido: args[1]);
            result = Result.Ok().WithSuccess(new SucessoComPet(listaDePets, "----- Serão importados os dados acima -----"));
        }
        catch (Exception ex)
        {
            result = Result.Fail(new Error("O camndo Exibição(show) falhou!").CausedBy(ex));
        }

        return Task.FromResult(result);
    }
    private List<Pet> ItensDoArquivo(string caminhoDoArquivoASerExibido)
    {
        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerExibido))
        {
            var leitorDeArquivos =  new LeitorDeArquivos(caminhoDoArquivoASerExibido);
            var pets = leitorDeArquivos.RealizarLeitura();
            return pets;
        }
    }
}