using System.Collections.ObjectModel;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using Moq;

namespace Alura.Adopet.Test;

public class LeitorDeArquivoTest
{
    private string caminhoArquivo;
    public LeitorDeArquivoTest()
    {
        //Setup
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        File.WriteAllText("lista.csv", linha);
        caminhoArquivo = Path.GetFullPath("lista.csv");
    }
    
    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Arrange            
        //Act
        var listaDePets = new LeitorDeArquivos().RealizarLeitura("")!;
        //Assert
        Assert.NotNull(listaDePets);
        Assert.Single(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    [Fact]
    public void QuandoArquivoNaoExistenteDeveRetornarNulo()
    {
        //Arrange            
        //Act
        var listaDePets = new LeitorDeArquivos().RealizarLeitura("");
        //Assert
        Assert.Null(listaDePets);
    }

    [Fact]
    public void QuandoArquivoForNuloDeveRetornarNulo()
    {
        //Arrange            
        //Act
        var listaDePets = new LeitorDeArquivos().RealizarLeitura(null);
        //Assert
        Assert.Null(listaDePets);
    }
        
    public void Dispose()
    {
        //ClearDown
        File.Delete(caminhoArquivo);
    }
}