using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using Alura.Adopet.Test.DataBuilder;
using Moq;

namespace Alura.Adopet.Test
{
    public class ImportTest
    {
        [Fact]
        public async Task DadoUmaListaVariaDeveVerificarSeOCreatAsyncExecutouPeloManoUmaVez()
        {
            List<Pet>? listaDePets = new List<Pet>();

            var leitorDeArquivo = LeitorDeArquivoMockBuilder.Novo(listaDePets);
            var httpClientPetMock = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
            var importar = new Importar(httpClientPetMock.Object, leitorDeArquivo.Object);
            var args = new string[] { "import", "animais.csv" };

            await importar.ExecutarAsync(args);
            
            httpClientPetMock.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
        }
    }
}
