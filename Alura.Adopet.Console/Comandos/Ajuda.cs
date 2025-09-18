using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "help", documentacao: "comando que exibe informações de ajuda.ao ")]
public class Ajuda :IComando
{
    private Dictionary<string, DocComando> docs;

    public Ajuda()
    {
        docs = DocumentacaoDoSistema.ObterTodos();
    }
    
    public Task<Result> ExecutarAsync(string[] args)
    {
        Result result;
        try
        {
            this.Executar(args);
            result = Result.Ok();
        }
        catch (Exception ex)
        {
            result = Result.Fail(new Error("O camndo Ajuda(help) falhou!").CausedBy(ex));
        }

        return Task.FromResult(result);
    }
    
    private void Executar(string[] parametrosInformados)
    {
        System.Console.WriteLine("Lista de comandos.");
        if (parametrosInformados.Length == 1)
        {
            System.Console.WriteLine(
                "adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");

            foreach (DocComando comando in docs.Values)
            {
                System.Console.WriteLine(comando.Documentacao);
            }
        }
        else if (parametrosInformados.Length == 2)
        {
            string comandoASerExibido = parametrosInformados[1];
            if (docs.ContainsKey(comandoASerExibido))
            {
                var comando = docs[comandoASerExibido];
                System.Console.WriteLine(comando.Documentacao);
            }
            else
            {
                System.Console.WriteLine($"adopet comando não encontrado.");
            }
        }
    }
}