using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Test;

public class ImportTest
{
    [Fact]
    public async Task QuandoAPIIEstaNoArDeveRetornarLista()
    {
        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        var importar = new Importar(httpClientPet);
        var args = new string[] { "import", "animais.csv" };

        await importar.ExecutarAsync(args);
        var listaPets = await httpClientPet.ListPetsAsync();

        Assert.NotNull(listaPets);
    }
}
