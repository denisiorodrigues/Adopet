using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "help", documentacao: "adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos.")]
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
            var listaDeDocumentacao = this.GerarDocumentacao(args);
            result = Result.Ok().WithSuccess(new SucessoComDocumentacao(listaDeDocumentacao));
        }
        catch (Exception ex)
        {
            result = Result.Fail(new Error("O camndo Ajuda(help) falhou!").CausedBy(ex));
        }

        return Task.FromResult(result);
    }
    
    private IEnumerable<string> GerarDocumentacao(string[] parametrosInformados)
    {
        var listaDeDocumentacao = new List<string>();
        if (parametrosInformados.Length == 1)
        {
            foreach (DocComando comando in docs.Values)
            {
                listaDeDocumentacao.Add(comando.Documentacao);
            }
        }
        else if (parametrosInformados.Length == 2)
        {
            string comandoASerExibido = parametrosInformados[1];
            if (docs.ContainsKey(comandoASerExibido))
            {
                var comando = docs[comandoASerExibido];
                listaDeDocumentacao.Add(comando.Documentacao);
            }
            else
            {
                listaDeDocumentacao.Add($"adopet comando não encontrado.");
            }
        }

        return listaDeDocumentacao;
    }
}