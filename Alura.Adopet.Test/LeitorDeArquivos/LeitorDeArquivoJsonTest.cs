using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Test.LeitorDeArquivos;

public class LeitorDeArquivoJsonTest : IDisposable
{
    private string caminhoArquivo;
    public LeitorDeArquivoJsonTest()
    {
        string conteudo = @"
            [
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
                ""Nome"": ""Mancha"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                ""Nome"": ""Alvo"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-1234-adab-0637511672e0"",
                ""Nome"": ""Pinta"",
                ""Tipo"": 1
              }
            ]
        ";

        string nomeRandomico = $"{Guid.NewGuid()}.json";

        File.WriteAllText(nomeRandomico, conteudo);
        caminhoArquivo = Path.GetFullPath(nomeRandomico);
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Act
        IEnumerable<Pet> listaDePets = new LeitorDeArquivoJson(caminhoArquivo).RealizarLeitura();

        //Assert
        Assert.NotNull(listaDePets);
        Assert.Equal(3, listaDePets.Count());
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    public void Dispose()
    {
        File.Delete(caminhoArquivo);
    }
}
