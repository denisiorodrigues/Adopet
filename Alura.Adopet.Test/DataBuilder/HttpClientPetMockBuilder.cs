using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using Moq;

namespace Alura.Adopet.Test.DataBuilder;

internal static class HttpClientPetMockBuilder
{
    public static Mock<HttpClientPet> GetMock()
    {
        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
            It.IsAny<HttpClient>());

        return httpClientPet;
    }

    public static Mock<HttpClientPet> GetMock(List<Pet> listaDePet)
    {
        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
            It.IsAny<HttpClient>());

        httpClientPet.Setup(_ => _.ListAsync())
            .ReturnsAsync(listaDePet);

        return httpClientPet;
    }
}
