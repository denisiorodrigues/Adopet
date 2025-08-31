using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Test;

public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
    {
        var docs = GeraDocumentacao.ObterTodos();
        Assert.NotEmpty(docs);
        Assert.Contains("help", docs.Keys);
        Assert.Contains("import", docs.Keys);
        Assert.Contains("list", docs.Keys);
        Assert.Contains("show", docs.Keys);
        Assert.DoesNotContain("qualquercoisa", docs.Keys);
        Assert.Equal(4, docs.Count);
    }
}
