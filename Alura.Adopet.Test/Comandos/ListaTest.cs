using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utilitarios;
using Alura.Adopet.Test.DataBuilder;

namespace Alura.Adopet.Test.Comandos
{
    public class ListaTest
    {
        [Fact]
        public async Task QuandoSolicitarParaListarDeveRetornarSucesso()
        {
            var listaDePets = PetBuilder.GetMock();
            var httpClientPetMock = HttpClientPetMockBuilder.GetMock(listaDePets);
            var comandoListar = new Listar(httpClientPetMock.Object);
            
            var retorno = await comandoListar.ExecutarAsync();

            var resultado = (SucessoComPet)retorno.Successes[0];
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Data.Count());
        }
    }
}
