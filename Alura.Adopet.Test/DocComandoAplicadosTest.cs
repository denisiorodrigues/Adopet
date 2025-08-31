namespace Alura.Adopet.Test;

public class DocComandoAplicadosTest
{
    [Fact]
    public void DeveRetornarTodasAsDocumentacoesComSucsso()
    {
        var docs = Console.Utilitarios.DocComandoAplicados.ObterTodos();
        Assert.NotEmpty(docs);
        Assert.Contains("help", docs.Keys);
        Assert.Contains("import", docs.Keys);
        Assert.Contains("list", docs.Keys);
        Assert.Contains("show", docs.Keys);
        Assert.DoesNotContain("qualquercoisa", docs.Keys);
        Assert.Equal(4, docs.Count);
    }
}
