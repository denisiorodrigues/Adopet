using Alura.Adopet.Console.Utilitarios;
using Alura.Adopet.Test.DataBuilder;
using Moq;

namespace Alura.Adopet.Test;

public class HttpClientPetTest
{
    [Fact]
    public async Task DeveRetornarUmaListaDePetsComSucesso()
    {
        var response = HttpResponseMessageBuilder.ListaDePetComSucesso();
        var handlerMock = HttpMessageHandlerMockBuilder.NovoRetornandoSucesso(response);
        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");
        var httpClientPet = new HttpClientPet(httpClient.Object);

        var pets = await httpClientPet.ListAsync();

        Assert.NotNull(pets);
        Assert.NotEmpty(pets);
    }

    [Fact]
    public async Task QuandoApiForaDeveRetornarUmaExcecao()
    {
        var handlerMock = HttpMessageHandlerMockBuilder.NovoRetornandoExcecao();
        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");
        var httpClientPet = new HttpClientPet(httpClient.Object);
        
        Assert.ThrowsAsync<Exception>(() => httpClientPet.ListAsync());
    }
}