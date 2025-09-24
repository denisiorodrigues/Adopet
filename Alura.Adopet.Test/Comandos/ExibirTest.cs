using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using Alura.Adopet.Test.DataBuilder;
using Moq;

namespace Alura.Adopet.Test.Comandos;

public class ExibirTest
{
    Mock<LeitorDeArquivos> LeitorDeArquivoMock;

    public ExibirTest()
    {
        var listaDePets = PetBuilder.GetMock();
        LeitorDeArquivoMock = LeitorDeArquivoMockBuilder.GetMock(listaDePets);
    }

    [Fact]
    public async Task QuandoExibirDeveRetonarUmResultadoDeSucessso()
    {
        var exibir = new Exibir(LeitorDeArquivoMock.Object);
        
        var result = await exibir.ExecutarAsync();
        var petComsuCesso = (SucessoComPet)result.Successes.First();


        Assert.True(result.IsSuccess);
        Assert.NotNull(petComsuCesso);
        Assert.Equal(2, petComsuCesso.Data.Count());
    }

    [Fact]
    public async Task QuandoExibirDeveRetornarFalha()
    {
        LeitorDeArquivoMock.Setup(l => l.RealizarLeitura()).Throws(new Exception());
        var exibir = new Exibir(LeitorDeArquivoMock.Object);

        var result = await exibir.ExecutarAsync();

        Assert.True(result.IsFailed);
        Assert.NotEmpty(result.Errors);
        Assert.Equal("O camndo Exibição(show) falhou!", result.Errors.First().Message);
    }
}
