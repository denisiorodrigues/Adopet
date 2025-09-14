using System.Net.Sockets;
using Moq;
using Moq.Protected;

namespace Alura.Adopet.Test.DataBuilder;

internal static class HttpMessageHandlerMockBuilder
{
    public static Mock<HttpMessageHandler> NovoRetornandoSucesso(HttpResponseMessage response)
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
        .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        return handlerMock;
    }

    public static Mock<HttpMessageHandler> NovoRetornandoExcecao()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new SocketException());

        return handlerMock;
    }
}
