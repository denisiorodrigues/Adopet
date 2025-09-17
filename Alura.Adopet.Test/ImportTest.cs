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

        [Fact]
        public async Task QuandoArquivoNaoExistenteDeveGerarException()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var leitor = LeitorDeArquivoMockBuilder.Novo(listaDePet);
            leitor.Setup(_ => _.RealizarLeitura()).Throws<FileNotFoundException>();

            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
                 It.IsAny<HttpClient>());

            string[] args = { "import", "lista.csv" };

            var import = new Importar(httpClientPet.Object, leitor.Object);

            //Act+Assert
            await Assert.ThrowsAnyAsync<Exception>(() => import.ExecutarAsync(args));
        }
    }
}
