using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Test;

public class FabricaDeComandoTest
{
    [Fact]
    public void DadoUmParametroDevetRetornarUmTipoImport()
    {
        string [] args = { "import", "lista.csv"};

        var comando = FabricaDeComandos.CriarComando(args);

        Assert.IsType<Importar>(comando);
    }

    [Fact]
    public void DadoUmParamtroInvalidoDeveRetornarNulo()
    {
        string[] args = { "invalido" };

        var comando = FabricaDeComandos.CriarComando(args);

        Assert.Null(comando);
    }

    [Fact]
    public void DadoNaoExistirArrayDeArgumentoDeveretornarNulo()
    {
        var comando = FabricaDeComandos.CriarComando(null);

        Assert.Null(comando);
    }


    [Fact]
    public void DadoUmArrayDeArgumentoVazioDeveretornarNulo()
    {
        string[] args = { };

        var comando = FabricaDeComandos.CriarComando(null);

        Assert.Null(comando);
    }
}
