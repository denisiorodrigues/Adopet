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
}
