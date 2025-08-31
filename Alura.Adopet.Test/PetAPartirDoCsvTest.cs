using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Test;

public class PetAPartirDoCsvTest
{
    [Fact]
    public void QuandoStringForValidaRetornaUmPet()
    {
        var linha = "609c9b0d-aa02-459f-a340-256513fc9bad;Nina;1";
        
        Pet pet = linha.ConverteDoTexto();
        
        Assert.NotNull(pet);
    }

    [Fact]
    public void QuandoStringVaziaDeveRetornarUmArgumentException()
    {
        string? linha = null;

        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoAQuantidadeDeCampoEInsuficienteDeveRetornarUmaExcecao()
    {
        var linha = "609c9b0d-aa02-459f-a340-256513fc9bad;Pet";
        
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }
    
    [Fact]
    public void QuandoInformarUmaGuidInvalidaDeveRetonarUmaArgumentException()
    {
        var linha = "sdad;Pet;1";
        
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }
    
    [Fact]
    public void QuandoTipoInvalidoDeveLancarArgumentException()
    {
        var linha = "609c9b0d-aa02-459f-a340-256513fc9bad;Pet;99";

        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }
}