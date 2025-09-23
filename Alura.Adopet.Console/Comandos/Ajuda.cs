using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "help", documentacao: "adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos.")]
public class Ajuda :IComando
{
    private Dictionary<string, DocComando> docs;
    private string? comandoASerExibido;

    public Ajuda(string? comandoASerExibido)
    {
        docs = DocumentacaoDoSistema.ObterTodos();
        this.comandoASerExibido = comandoASerExibido;
    }

    public Task<Result> ExecutarAsync()
    {
        Result result;
        try
        {
            var listaDeDocumentacao = this.GerarDocumentacao();
            result = Result.Ok().WithSuccess(new SucessoComDocumentacao(listaDeDocumentacao));
        }
        catch (Exception ex)
        {
            result = Result.Fail(new Error("O camndo Ajuda(help) falhou!").CausedBy(ex));
        }

        return Task.FromResult(result);
    }
    
    private IEnumerable<string> GerarDocumentacao()
    {
        var listaDeDocumentacao = new List<string>();
        if (this.comandoASerExibido is null)
        {
            foreach (DocComando comando in docs.Values)
            {
                listaDeDocumentacao.Add(comando.Documentacao);
            }
        }
        else
        {
            if (docs.ContainsKey(this.comandoASerExibido))
            {
                var comando = docs[this.comandoASerExibido];
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