using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Test;

public class HttpClientPetTest
{
    [Fact]
    public async Task DeveRetornarUmaListaDePetsComSucesso()
    {
        var httpClientPet = new HttpClientPet();

        var pets = await httpClientPet.ListPetsAsync();

        Assert.NotNull(pets);
        Assert.NotEmpty(pets);
    }
}