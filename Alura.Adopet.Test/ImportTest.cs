using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using Moq;

namespace Alura.Adopet.Test
{
    public class ImportTest
    {
        [Fact]
        public async Task DadoUmaListaVariaDeveVerificarSeOCreatAsyncExecutouPeloManoUmaVez()
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivos>(MockBehavior.Default, It.IsAny<string>());
            //var pet = new Pet(new Guid(), "Lima", TipoPet.Cachorro);
            //var listaDePets = new List<Pet>() { pet };
            List<Pet>? listaDePets = new List<Pet>();
            leitorDeArquivo.Setup(_ => _.RealizarLeitura()).Returns(listaDePets);
            var httpClientPetMock = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
            var importar = new Importar(httpClientPetMock.Object, leitorDeArquivo.Object);
            var args = new string[] { "import", "animais.csv" };

            await importar.ExecutarAsync(args);
            
            httpClientPetMock.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
        }
    }
}
