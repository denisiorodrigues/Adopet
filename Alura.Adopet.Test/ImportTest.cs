using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utilitarios;
using Moq;

namespace Alura.Adopet.Test;

public class ImportTest
{
    [Fact]
    public async Task QuandoAPIIEstaNoArDeveRetornarLista()
    {
        var leitorDeArquivo = new Mock<LeitorDeArquivos>(MockBehavior.Default, It.IsAny<string>());
        var pet = new Pet(new Guid(), "Lima", TipoPet.Cachorro);
        leitorDeArquivo.Setup(_ => _.RealizarLeitura()).Returns(new List<Pet>() { pet });

        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        var importar = new Importar(httpClientPet, leitorDeArquivo.Object);
        var args = new string[] { "import", "animais.csv" };

        await importar.ExecutarAsync(args);
        var listaPets = await httpClientPet.ListPetsAsync();

        Assert.NotNull(listaPets);
    }
}
