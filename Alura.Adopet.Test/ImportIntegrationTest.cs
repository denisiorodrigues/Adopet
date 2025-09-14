using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utilitarios;
using Alura.Adopet.Test.DataBuilder;

namespace Alura.Adopet.Test;

public class ImportIntegrationTest
{
    [Fact]
    public async Task QuandoAPIIEstaNoArDeveRetornarLista()
    {
        var pet = new Pet(new Guid(), "Lima", TipoPet.Cachorro);
        var listaDePet = new List<Pet>() { pet };

        var leitorDeArquivo = LeitorDeArquivoMockBuilder.Novo(listaDePet);

        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        var importar = new Importar(httpClientPet, leitorDeArquivo.Object);
        var args = new string[] { "import", "animais.csv" };

        await importar.ExecutarAsync(args);
        var listaPets = await httpClientPet.ListPetsAsync();

        Assert.NotNull(listaPets);
    }
}
