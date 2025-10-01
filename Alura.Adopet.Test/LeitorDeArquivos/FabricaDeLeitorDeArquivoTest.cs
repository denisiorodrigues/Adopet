using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Test.LeitorDeArquivos;

public class FabricaDeLeitorDeArquivoTest
{
    [Fact]
    public void QuandoExtensaoForCsvDeveRetornarLeitorDeArquivoCsv()
    {
        //Arrange
        string caminhoArquivo = "arquivo.csv";
        
        //Act
        var leitor = FabricaDeLeitorDeArquivo.CriarLeitor(caminhoArquivo);
        
        //Assert
        Assert.NotNull(leitor);
        Assert.IsType<LeitorDeArquivoCsv>(leitor);
    }

    [Fact]
    public void QuandoExtensaoForJsonDeveRetornarLeitorDeArquivoJson()
    {
        //Arrange
        string caminhoArquivo = "arquivo.json";
        
        //Act
        var leitor = FabricaDeLeitorDeArquivo.CriarLeitor(caminhoArquivo);
        
        //Assert
        Assert.NotNull(leitor);
        Assert.IsType<LeitorDeArquivoJson>(leitor);
    }

    [Fact]
    public void QuandoExtensaoForInvalidaDeveRetornarNulo()
    {
        //Arrange
        string caminhoArquivo = "arquivo.txt";
        
        //Act
        var leitor = FabricaDeLeitorDeArquivo.CriarLeitor(caminhoArquivo);
        
        //Assert
        Assert.Null(leitor);
    }
}
