using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Test;

public class PetAPartirDoCsvTest
{
    [Fact]
    public void QuandoStringForValidaRetornaUmPet()
    {
        var linha = "609c9b0d-aa02-459f-a340-256513fc9bad;Nina;2";
        
        Pet pet = linha.ConverteDoTexto();
        
        Assert.NotNull(pet);
    }

    [Fact]
    public void QuandoStringVaziaDeveRetornarUmPetNulo()
    {
        var linha = string.Empty;
        
        Pet pet = linha.ConverteDoTexto();
        
        Assert.Null(pet);
    }

    [Fact]
    public void QuandoAQuantidadeDeCampoEInsuficienteDeveRetornarUmaExcecao()
    {
        var linha = "609c9b0d-aa02-459f-a340-256513fc9bad";
        
        Assert.Throws<IndexOutOfRangeException>(() => linha.ConverteDoTexto());
    }
    
    [Fact]
    public void QuandoInformarUmaGuidInvalidaDeveRetonarUmaFormatException()
    {
        var linha = "609c9b0d";
        
        Assert.Throws<FormatException>(() => linha.ConverteDoTexto());
    }
}