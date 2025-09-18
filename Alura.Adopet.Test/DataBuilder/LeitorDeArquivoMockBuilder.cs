using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using Moq;

namespace Alura.Adopet.Test.DataBuilder;

internal static class LeitorDeArquivoMockBuilder
{
    public static Mock<LeitorDeArquivos> GetMock(List<Pet> listaDePet)
    {
        var leitorDeArquivoMock = new Mock<LeitorDeArquivos>(MockBehavior.Default, It.IsAny<string>());
        leitorDeArquivoMock.Setup(_ => _.RealizarLeitura()).Returns(listaDePet);

        return leitorDeArquivoMock;
    }

    public static Mock<LeitorDeArquivos> GetMock()
    {
        var leitorDeArquivoMock = new Mock<LeitorDeArquivos>(MockBehavior.Default, It.IsAny<string>());

        return leitorDeArquivoMock;
    }
}
