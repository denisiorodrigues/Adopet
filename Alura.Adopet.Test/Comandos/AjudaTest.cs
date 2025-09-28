using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Test.Comandos;

public class AjudaTest
{
    [Fact]
    public async Task QuandoOComandoNaoExisteDeveRetornarFalha()
    {
        var comando = "Invalido";
        var comandoAjuda = new Ajuda(comando);

        var resultado = await comandoAjuda.ExecutarAsync();

        Assert.NotNull(resultado);
        Assert.True(resultado.IsFailed);
    }

    [Theory]
    [InlineData("import")]
    [InlineData("help")]
    [InlineData("list")]
    [InlineData("show")]
    public async Task QuandoOcomandoExistirDeveRetornarSucesso(string comando)
    {
        var comandoAjuda = new Ajuda(comando);

        var resultado = await comandoAjuda.ExecutarAsync();

        Assert.NotNull(resultado);
        Assert.True(resultado.IsSuccess);
    }
}
