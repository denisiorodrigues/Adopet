using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using Alura.Adopet.Test.DataBuilder;
using Moq;

namespace Alura.Adopet.Test.Comandos
{
    public class ImportarTest
    {
        [Fact]
        public async Task DadoUmaListaVariaDeveVerificarSeOCreatAsyncExecutouPeloManoUmaVez()
        {
            List<Pet>? listaDePets = new List<Pet>();

            var leitorDeArquivo = LeitorDeArquivoMockBuilder.GetMock(listaDePets);
            var httpClientPetMock = HttpClientPetMockBuilder.GetMock();
            var importar = new Importar(httpClientPetMock.Object, leitorDeArquivo.Object);
            var args = new string[] { "import", "animais.csv" };

            await importar.ExecutarAsync();
            
            httpClientPetMock.Verify(_ => _.CreateAsync(It.IsAny<Pet>()), Times.Never);
        }

        [Fact]
        public async Task QuandoArquivoNaoExistenteDeveGerarException()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var leitor = LeitorDeArquivoMockBuilder.GetMock(listaDePet);
            leitor.Setup(_ => _.RealizarLeitura()).Throws<FileNotFoundException>();

            var httpClientPet = HttpClientPetMockBuilder.GetMock();

            string[] args = { "import", "lista.csv" };

            var import = new Importar(httpClientPet.Object, leitor.Object);

            //Act+Assert
            var resultado = await import.ExecutarAsync();

            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                                        "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);
            var leitorDeArquivo = LeitorDeArquivoMockBuilder.GetMock(listaDePet);

            var httpClientPet = HttpClientPetMockBuilder.GetMock();

            var import = new Importar(httpClientPet.Object, leitorDeArquivo.Object);
            string[] args = { "import", "lista.csv" };
            //Act
            var resultado = await import.ExecutarAsync();
            var sucesso = resultado.Successes[0] as SucessoComPet;
            
            //Assert
            Assert.True(resultado.IsSuccess);
            Assert.Equal("Lima", sucesso.Data.First().Nome);
        }
    }
}
