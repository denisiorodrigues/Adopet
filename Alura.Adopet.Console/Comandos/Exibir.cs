using Alura.Adopet.Console.Atributos;
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
            this.ItensDoArquivo(caminhoDoArquivoASerExibido: args[1]);
            result = Result.Ok();
        }
        catch (Exception ex)
        {
            result = Result.Fail(new Error("O camndo Exibição(show) falhou!").CausedBy(ex));
        }

        return Task.FromResult(result);
    }
    private void ItensDoArquivo(string caminhoDoArquivoASerExibido)
    {
        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerExibido))
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            var leitorDeArquivos =  new LeitorDeArquivos(caminhoDoArquivoASerExibido);
            var pets = leitorDeArquivos.RealizarLeitura();
            foreach (var pet in pets) 
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}